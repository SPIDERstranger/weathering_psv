﻿
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Weathering
{
    public interface IPassable
    {
        bool Passable { get; }
    }

    public interface IStepOn
    {
        void OnStepOn();
    }

    public interface IMapView
    {
        /// <summary>
        /// 设置和获取当前显示的地图。同时只会显示一个地图。
        /// </summary>
        IMap TheOnlyActiveMap { get; set; }

        Camera MainCamera { get; }

        Vector2 CameraPosition { get; set; }

        Vector2Int CharacterPosition { get; set; }

        Color ClearColor { get; set; }

        float TappingSensitivityFactor { get; set; }
        long AnimationIndex { get; }
    }

    // IgnoreTool的ITile会忽略选中的工具影响
    public interface IIgnoreTool
    {
        bool IgnoreTool { get; }
    }

    public interface IHasFrameAnimationOnSpriteKey
    {
        bool HasFrameAnimation { get; }
    }

    public class MapView : MonoBehaviour, IMapView
    {
        public static IMapView Ins { get; private set; }

        private void Awake() {
            if (Ins != null) throw new Exception();
            Ins = this;
            mainCameraTransform = mainCamera.transform;
            playerCharacterTransform = playerCharacter.transform;
        }

        public IMap TheOnlyActiveMap { get; set; }

        public Camera MainCamera { get => mainCamera; }

        public float CameraSize {
            get => mainCamera.orthographicSize;
            set {
                mainCamera.orthographicSize = value;
            }
        }

        public Vector2 CameraPosition {
            get {
                return mainCameraTransform.position;
            }
            set {
                mainCameraTransform.position
                    = new Vector3(value.x, value.y,
                    mainCameraTransform.position.z);
            }
        }

        private Vector2Int CharacterPositionInternal;
        public Vector2Int CharacterPosition {
            get => CharacterPositionInternal; set {
                CharacterPositionInternal = value;
            }
        }

        public Color ClearColor {
            get {
                return mainCamera.backgroundColor;
            }
            set {
                mainCamera.backgroundColor = value;
            }
        }


        private void Start() {
            characterView.SetCharacterSprite(lastTimeMovement, false);
        }
        private int width;
        private int height;
        private bool mapControlPlayerLastTime = false;
        private void Update() {
            // 按下ESC键打开关闭菜单
            if (GameMenu.IsInStandalone) {
                CheckESCKey();
            }
            IMapDefinition map = TheOnlyActiveMap as IMapDefinition;
            if (map == null) throw new Exception();
            width = map.Width;
            height = map.Height;
            UpdateInput();
            if (map != null) {
                if (map.ControlCharacter) {
                    playerCharacter.SetActive(true);
                    if (!UI.Ins.Active) {
                        UpdateCharacterWithTappingAndArrowKey();
                    }
                    CorrectCharacterPosition();
                    CameraFollowsCharacter();
                    if (!mapControlPlayerLastTime) {
                        SyncCharacterPosition();
                    }
                    mapControlPlayerLastTime = true;
                } else {
                    playerCharacter.SetActive(false);
                    if (!UI.Ins.Active) {
                        UpdateCameraWithTapping();
                        UpdateCameraWidthArrowKey();
                    }
                    CorrectCameraPosition();
                    mapControlPlayerLastTime = false;
                }
                UpdateMap();
                UpdateMapAnimation();
                map.Update();
            } else {
                throw new Exception();
            }
        }

        private void SyncCharacterPosition() {
            Vector3 displayPositionOfCharacter = GetRealPositionOfCharacter();
            playerCharacterTransform.position = displayPositionOfCharacter;
            mainCameraTransform.position = new Vector3(displayPositionOfCharacter.x, displayPositionOfCharacter.y, cameraZ);
        }

        private void CheckESCKey() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (UI.Ins.Active) {
                    UI.Ins.Active = false;
                } else {
                    GameMenu.Ins.OnTapSettings();
                }
            }
        }

        private const float cameraSpeed = 5;
        private void UpdateCameraWidthArrowKey() {
            float ratio = cameraSpeed * Time.deltaTime * TappingSensitivityFactor * ScreenAdaptation.Ins.DoubleSizeMultiplier;
            if (Input.GetKey(KeyCode.RightArrow)) {
                target = mainCameraTransform.position + Vector3.right * ratio;
                mainCameraTransform.position = target;
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                target = mainCameraTransform.position + Vector3.left * ratio;
                mainCameraTransform.position = target;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                target = mainCameraTransform.position + Vector3.up * ratio;
                mainCameraTransform.position = target;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                target = mainCameraTransform.position + Vector3.down * ratio;
                mainCameraTransform.position = target;
            }
        }

        public class TappingSensitivity { }

        public const float DefaultTappingSensitivity = 2f;
        public float TappingSensitivityFactor { get; set; } = 2f;
        private void UpdateCameraWithTapping() {
            if (!tapping) return;
            Vector2 cameraDeltaDistance = deltaDistance * Time.deltaTime * TappingSensitivityFactor * cameraSpeed * ScreenAdaptation.Ins.DoubleSizeMultiplier;
            mainCameraTransform.position += (Vector3)cameraDeltaDistance;
        }

        Vector2Int characterMovement = Vector2Int.zero;
        private float lastTimeUpdated = 0;
        private Vector2Int lastTimeMovement = Vector2Int.down;

        // 人物走过1格需要的时间
        private const float WalkingTimeForUnitTileBase = 0.3f;
        private float WalkingTimeForUnitTile = WalkingTimeForUnitTileBase;
        private void UpdateCharacterWithTappingAndArrowKey() {
            if (tapping || Input.anyKey) {
                characterMovement = Vector2Int.zero;
                float absX = Mathf.Abs(deltaDistance.x);
                float absY = Mathf.Abs(deltaDistance.y);
                const float deadZoneRadius = 0.5f;
                if (tapping) {
                    if (absX > absY) {
                        if (absX > deadZoneRadius) {
                            if (deltaDistance.x > 0) {
                                characterMovement = Vector2Int.right;
                            } else {
                                characterMovement = Vector2Int.left;
                            }
                        }
                    } else {
                        if (absY > deadZoneRadius) {
                            if (deltaDistance.y > 0) {
                                characterMovement = Vector2Int.up;
                            } else {
                                characterMovement = Vector2Int.down;
                            }
                        }
                    }
                } else {
                    if (Input.GetKey(KeyCode.LeftArrow)) characterMovement = Vector2Int.left;
                    if (Input.GetKey(KeyCode.RightArrow)) characterMovement = Vector2Int.right;
                    if (Input.GetKey(KeyCode.UpArrow)) characterMovement = Vector2Int.up;
                    if (Input.GetKey(KeyCode.DownArrow)) characterMovement = Vector2Int.down;
                }

                if (characterMovement != Vector2Int.zero) {
                    Vector2Int newPosition = CharacterPositionInternal + characterMovement;
                    // IPassable用于判断能否此地块能否通过
                    ITile oldTile = TheOnlyActiveMap.Get(CharacterPositionInternal);
                    IPassable oldPassable = oldTile as IPassable;
                    bool oldIsPassable = oldPassable != null && oldPassable.Passable;
                    ITile newTile = TheOnlyActiveMap.Get(newPosition);
                    IPassable newPassable = newTile as IPassable;
                    bool newIsPassable = newPassable != null && newPassable.Passable;

                    StandardMap standardMap = TheOnlyActiveMap as StandardMap;
                    if (standardMap == null) throw new Exception(); // 强耦合了

                    // TerrainDefault.IsPassable(TheOnlyActiveMap as StandardMap, newPosition);
                    // TerrainDefault.IsPassable(TheOnlyActiveMap as StandardMap, CharacterPositionInternal);

                    //IPassable passableTile = tileStepOn as IPassable;
                    //if (passableTile == null) {
                    //    passable = true;
                    //}
                    //if (passableTile != null) {
                    //    passable = passableTile.Passable;
                    //    if (!passable) {
                    //        IPassable passableTileSelf = TheOnlyActiveMap.Get(CharacterPositionInternal) as IPassable;
                    //        if (passableTileSelf == null) {
                    //            passable = false;
                    //        } else {
                    //            passable = !passableTileSelf.Passable;
                    //        }
                    //    }
                    //}
                    if (newIsPassable || !oldIsPassable) {
                        if (Time.time > lastTimeUpdated + WalkingTimeForUnitTile) {
                            lastTimeUpdated = Time.time;
                            CharacterPosition = newPosition; // CharacterPositionInternal += characterMovement;
                            if (newTile is IStepOn step) {
                                try {
                                    step.OnStepOn();
                                } catch (Exception e) {
                                    UI.Ins.ShowItems("踩到一个错误！！！", UIItem.CreateText(e.GetType().Name), UIItem.CreateMultilineText(e.Message), UIItem.CreateMultilineText(e.StackTrace));
                                    throw e;
                                }
                            }
                        }
                    }
                    lastTimeMovement = characterMovement;
                }
            }
        }

        private bool corrected = false;
        private Vector2Int correctingVector = Vector2Int.zero;
        private void CorrectCharacterPosition() {
            Vector2Int characterPosition = CharacterPositionInternal;
            corrected = false;
            correctingVector = Vector2Int.zero;
            if (characterPosition.x >= width) {
                characterPosition.x -= width;
                corrected = true;
                correctingVector = new Vector2Int(-width, 0);
            } else if (characterPosition.x < 0) {
                characterPosition.x += width;
                corrected = true;
                correctingVector = new Vector2Int(width, 0);
            }
            if (characterPosition.y >= height) {
                characterPosition.y -= height;
                corrected = true;
                correctingVector = new Vector2Int(0, -height);
            } else if (characterPosition.y < 0) {
                characterPosition.y += height;
                corrected = true;
                correctingVector = new Vector2Int(0, height);
            }
            CharacterPositionInternal = characterPosition;
            if (corrected) {
                Vector3 offset = (Vector3Int)correctingVector;
                mainCameraTransform.position += offset;
                playerCharacterTransform.position += offset;
            }
        }


        private const int cameraZ = -17;
        private Vector3 GetRealPositionOfCharacter() {
            return new Vector3(CharacterPositionInternal.x + 0.5f, CharacterPositionInternal.y + 0.5f, 0);
        }
        private const float moreAnimationTimeInSecond = 0.05f; // 动画
        private float movingLastTime = 0;
        private void CameraFollowsCharacter() {
            // 调整走路速度
            ITile tile = TheOnlyActiveMap.Get(CharacterPositionInternal.x, CharacterPositionInternal.y);
            if (tile is IWalkingTimeModifier walkingTimeModifier) {
                float modifier = walkingTimeModifier.WalkingTimeModifier;
                modifier = Mathf.Clamp(modifier, 0.2f, 3f);
                WalkingTimeForUnitTile = modifier * WalkingTimeForUnitTileBase;
            } else {
                WalkingTimeForUnitTile = WalkingTimeForUnitTileBase;
            }

            // 移动人物和相机
            Vector3 displayPositionOfCharacter = GetRealPositionOfCharacter();
            Vector3 deltaPosition = displayPositionOfCharacter - playerCharacterTransform.position;
            Vector3 newPosition = playerCharacterTransform.position + deltaPosition.normalized * Time.deltaTime / WalkingTimeForUnitTile;
            float deltaPositionSqrMagnitude = deltaPosition.sqrMagnitude;
            bool moving = deltaPosition.sqrMagnitude > 0.001f;
            if (!moving || deltaPositionSqrMagnitude < (newPosition - displayPositionOfCharacter).sqrMagnitude) {
                playerCharacterTransform.position = displayPositionOfCharacter;
            } else {
                playerCharacterTransform.position = newPosition;
            }
            if (moving) {
                movingLastTime = Time.time;
            }
            characterView.SetCharacterSprite(lastTimeMovement, moving || (Time.time - movingLastTime) < moreAnimationTimeInSecond); // 不会短暂停止动画
            mainCameraTransform.position = new Vector3(playerCharacterTransform.position.x, playerCharacterTransform.position.y, cameraZ);
        }


        private Vector3 target;
        private void CorrectCameraPosition() {
            target = mainCameraTransform.position;
            if (target.x > width) {
                target.x -= width; ;
            } else if (target.x < 0) {
                target.x += width;
            }
            if (target.y > height) {
                target.y -= height;
            } else if (target.y < 0) {
                target.y += height;
            }
            target.z = cameraZ;
            mainCameraTransform.position = target;
        }

        public long AnimationIndex { get; private set; } = 0;
        private const long animationUpdateRate = 100;
        private long animationFrameLastTime = 0;
        private long animationFrame = 0;
        private int animationScanerIndexOffsetY = 0;

        public int CameraWidthHalf { get; set; } = 5;
        public int CameraHeightHalf { get; set; } = 5;
        private void UpdateMap() {
            if (TheOnlyActiveMap as StandardMap == null) throw new Exception(); // 现在地图只能继承StandardMap，已经强耦合了。实现一个其他的IMapDefinition挺难的
            Vector3 pos = mainCameraTransform.position;
            int x = (int)pos.x;
            int y = (int)pos.y;


            // 动画更新tile会从下而上扫过横排，把部分SetTile开销分配到不同的帧。如果渲染压力过大，还会停止一些帧。其实SetTile消耗很小的，过度考虑了。有垂直同步问题
            int startY = y - CameraHeightHalf;
            int endY = y + CameraHeightHalf;

            if (animationScanerIndexOffsetY <= endY - startY) {
                animationScanerIndexOffsetY++;
            }

            // 每100毫秒，刷新一下动画
            animationFrame = TimeUtility.GetMiniSeconds();
            if (animationFrame - animationFrameLastTime > animationUpdateRate) {
                animationFrameLastTime = animationFrame;
                AnimationIndex++;

                if (animationScanerIndexOffsetY > endY - startY) {
                    animationScanerIndexOffsetY = 0;
                }
            }

            IRes res = Res.Ins;
            for (int i = x - CameraWidthHalf; i <= x + CameraWidthHalf; i++) {
                for (int j = startY; j <= endY; j++) {
                    ITileDefinition iTile = TheOnlyActiveMap.Get(i, j) as ITileDefinition;

                    // Tile缓存优化，使用了NeedUpdateSpriteKey TileSpriteKeyBuffer
                    Tile tileBackground = null;
                    Tile tileBase = null;
                    Tile tileRoad = null;
                    Tile tile = null;
                    Tile tileOverlay = null;

                    bool needUpdateFrameAnimationForThisTile = (animationScanerIndexOffsetY + startY == j)
                        && iTile is IHasFrameAnimationOnSpriteKey hasFrameAnimationOnSpriteKey
                        && hasFrameAnimationOnSpriteKey.HasFrameAnimation;
                    bool needUpdateSpriteKey = iTile.NeedUpdateSpriteKeys || needUpdateFrameAnimationForThisTile;

                    if (needUpdateSpriteKey) {

                        string spriteKeyBackground = iTile.SpriteKeyBackground;
                        if (spriteKeyBackground != null && !res.TryGetTile(spriteKeyBackground, out tileBackground)) {
                            throw new Exception($"Tile {spriteKeyBackground} not found for ITile {iTile.GetType().Name}");
                        }
                        iTile.TileSpriteKeyBackgroundBuffer = tileBackground;

                        string spriteKeyBase = iTile.SpriteKeyBase;
                        if (spriteKeyBase != null && !res.TryGetTile(spriteKeyBase, out tileBase)) {
                            throw new Exception($"Tile {spriteKeyBase} not found for ITile {iTile.GetType().Name}");
                        }
                        iTile.TileSpriteKeyBaseBuffer = tileBase;

                        string spriteKeyRoad = iTile.SpriteKeyRoad;
                        if (spriteKeyRoad != null && !res.TryGetTile(spriteKeyRoad, out tileRoad)) {
                            throw new Exception($"Tile {spriteKeyRoad} not found for ITile {iTile.GetType().Name}");
                        }
                        iTile.TileSpriteKeyRoadBuffer = tileRoad;

                        string spriteKey = iTile.SpriteKey;
                        if (spriteKey != null && !res.TryGetTile(spriteKey, out tile)) {
                            throw new Exception($"Tile {spriteKey} not found for ITile {iTile.GetType().Name}");
                        }
                        iTile.TileSpriteKeyBuffer = tile;

                        string spriteKeyOverlay = iTile.SpriteKeyOverlay;
                        if (spriteKeyOverlay != null && !res.TryGetTile(spriteKeyOverlay, out tileOverlay)) {
                            throw new Exception($"Tile {spriteKeyOverlay} not found for ITile {iTile.GetType().Name}");
                        }
                        iTile.TileSpriteKeyOverlayBuffer = tileOverlay;
                    } else {
                        tileBackground = iTile.TileSpriteKeyBackgroundBuffer;
                        tileBase = iTile.TileSpriteKeyBaseBuffer;
                        tileRoad = iTile.TileSpriteKeyRoadBuffer;
                        tile = iTile.TileSpriteKeyBuffer;
                        tileOverlay = iTile.TileSpriteKeyOverlayBuffer;
                    }

                    Tile tileLeft = null;
                    Tile tileRight = null;
                    Tile tileUp = null;
                    Tile tileDown = null;
                    if (needUpdateSpriteKey) {
                        string spriteLeft = iTile.SpriteLeft;
                        if (spriteLeft != null && !res.TryGetTile(spriteLeft, out tileLeft)) {
                            throw new Exception($"Tile {spriteLeft} not found for ITile {iTile.GetType().Name}, in sprite left");
                        }
                        iTile.TileSpriteKeyLeftBuffer = tileLeft;

                        string spriteRight = iTile.SpriteRight;
                        if (spriteRight != null && !res.TryGetTile(spriteRight, out tileRight)) {
                            throw new Exception($"Tile {spriteRight} not found for ITile {iTile.GetType().Name}, in sprite right");
                        }
                        iTile.TileSpriteKeyRightBuffer = tileRight;

                        string spriteUp = iTile.SpriteUp;
                        if (spriteUp != null && !res.TryGetTile(spriteUp, out tileUp)) {
                            throw new Exception($"Tile {spriteUp} not found for ITile {iTile.GetType().Name}, in sprite up");
                        }
                        iTile.TileSpriteKeyUpBuffer = tileUp;

                        string spriteDown = iTile.SpriteDown;
                        if (spriteDown != null && !res.TryGetTile(spriteDown, out tileDown)) {
                            throw new Exception($"Tile {spriteDown} not found for ITile {iTile.GetType().Name}, in sprite down");
                        }
                        iTile.TileSpriteKeyDownBuffer = tileDown;

                    } else {
                        tileLeft = iTile.TileSpriteKeyLeftBuffer;
                        tileRight = iTile.TileSpriteKeyRightBuffer;
                        tileUp = iTile.TileSpriteKeyUpBuffer;
                        tileDown = iTile.TileSpriteKeyDownBuffer;
                    }

                    if (needUpdateSpriteKey || iTile.NeedUpdateSpriteKeysPositionX != i || iTile.NeedUpdateSpriteKeysPositionY != j) {
                        Vector3Int pos3d = new Vector3Int(i, j, 0);
                        tilemapBackground.SetTile(pos3d, tileBackground);
                        tilemapBase.SetTile(pos3d, tileBase);
                        tilemapRoad.SetTile(pos3d, tileRoad);
                        tilemapLeft.SetTile(pos3d, tileLeft);
                        tilemapRight.SetTile(pos3d, tileRight);
                        tilemapUp.SetTile(pos3d, tileUp);
                        tilemapDown.SetTile(pos3d, tileDown);
                        tilemap.SetTile(pos3d, tile);
                        tilemapOverlay.SetTile(pos3d, tileOverlay);

                        iTile.NeedUpdateSpriteKeys = false;
                        iTile.NeedUpdateSpriteKeysPositionX = i;
                        iTile.NeedUpdateSpriteKeysPositionY = j;
                    }
                }
            }
        }

        private void UpdateMapAnimation() {
            double time = TimeUtility.GetMiniSecondsInDouble();
            long longTime = (long)time;

            long size = 1000;
            long remider = longTime % size;

            float t = (float)remider / size;
            float fraction;
            if (GameMenu.IsLinear) {
                fraction = Mathf.Lerp(0, 1, EaseFuncUtility.Linear(t)); // (float)(time - longTime);
            } else {
                fraction = Mathf.Lerp(0, 1, EaseFuncUtility.EaseInOutCubic(EaseFuncUtility.ShrinkOnHalf(t, 0.2f))); // (float)(time - longTime);
            }

            //const long wait = 100;
            //if (remider < wait) {
            //    fraction = 0;
            //} else if (remider > size - wait) {
            //    fraction = 1;
            //} else {
            //    if (GameMenu.IsLinear) {
            //    } else {
            //    }
            //}

            tilemapLeft.transform.position = Vector3.left * fraction + Vector3.right;
            tilemapRight.transform.position = Vector3.right * fraction + Vector3.left;
            tilemapUp.transform.position = Vector3.up * fraction + Vector3.down;
            tilemapDown.transform.position = Vector3.down * fraction + Vector3.up;
        }

        [SerializeField]
        private Tilemap tilemapBackground;
        [SerializeField]
        private Tilemap tilemapBase;
        [SerializeField]
        private Tilemap tilemapRoad;
        [SerializeField]
        private Tilemap tilemapLeft;
        [SerializeField]
        private Tilemap tilemapRight;
        [SerializeField]
        private Tilemap tilemapUp;
        [SerializeField]
        private Tilemap tilemapDown;
        [SerializeField]
        private Tilemap tilemap;
        [SerializeField]
        private Tilemap tilemapOverlay;

        [SerializeField]
        private Camera mainCamera;
        private Transform mainCameraTransform;
        [SerializeField]
        private GameObject playerCharacter;
        private Transform playerCharacterTransform;

        [SerializeField]
        private CharacterView characterView;

        [SerializeField]
        private Transform Head;
        [SerializeField]
        private Transform Tail;

        private bool tapping = false;
        private const float tappingSensitivity = 0.05f;

        private Vector2 tailMousePosition;
        //private Vector2 originalMousePosition;
        private Vector3 originalDownMousePosition;
        private Vector2 deltaDistance;

        private Vector2 tail;
        private bool hasBeenOutOfTheSameTile;
        private void UpdateInput() {
            Vector2 mousePosition = Input.mousePosition;

            tapping = false;
            Vector2 head = mainCamera.ScreenToWorldPoint(mousePosition);
            if (Input.GetMouseButtonDown(0)) {
                //originalMousePosition = mousePosition;
                originalDownMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
                tailMousePosition = mousePosition;
                hasBeenOutOfTheSameTile = false;
            }

            bool onSameTile = false;
            Vector2Int nowInt = MathVector2Floor(head);
            if (nowInt == MathVector2Floor(originalDownMousePosition)) {
                onSameTile = true;
            } else {
                hasBeenOutOfTheSameTile = true;
            }

            bool showHeadAndTail = false;

            if (Input.GetMouseButton(0)) {
                float radius = Math.Min(Screen.width, Screen.height) / 10;
                Vector2 deltaMousePosition = mousePosition - tailMousePosition;
                if (deltaMousePosition.sqrMagnitude > radius * radius) {
                    tailMousePosition += deltaMousePosition * Mathf.Min(0.64f, Time.deltaTime * 10);
                }

                tail = mainCamera.ScreenToWorldPoint(tailMousePosition);

                deltaDistance = head - tail;
                if (GameMenu.UseInversedMovement) {
                    deltaDistance = -deltaDistance;
                }
                if (deltaDistance.sqrMagnitude > 1f) {
                    deltaDistance.Normalize();
                }
                tapping = deltaDistance.sqrMagnitude > tappingSensitivity * tappingSensitivity;

                showHeadAndTail = !UI.Ins.Active && tapping && (!onSameTile || hasBeenOutOfTheSameTile);

                // 拖拽按钮显示条件：主UI不显示，正在拖拽，在相同格子上放下
                // bool showHeadAndTail = !UI.Ins.Active && tapping && (!onSameTile || hasBeenOutOfTheSameTile);
                Head.gameObject.SetActive(showHeadAndTail);
                Tail.gameObject.SetActive(showHeadAndTail);


                Head.localPosition = head;
                Tail.localPosition = tail;

                // 移动端金色边框显示条件：主UI不显示，拖拽UI不显示
                if (GameMenu.IsInMobile) {
                    Indicator.SetActive(!showHeadAndTail && !UI.Ins.Active);

                }
                if (!showHeadAndTail) {
                    UpdateIndicator(MathVector2Floor(mainCamera.ScreenToWorldPoint(mousePosition)));
                }
            }
            if (GameMenu.IsInStandalone) {
                bool showIndicator = !UI.Ins.Active && !showHeadAndTail;
                Indicator.SetActive(showIndicator);
                if (showIndicator) {
                    UpdateIndicator(MathVector2Floor(mainCamera.ScreenToWorldPoint(mousePosition)));
                }

                ITile tile = TheOnlyActiveMap.Get(nowInt.x, nowInt.y);
                if (tile != theTileToBeTapped) {
                    if (tile is ITileDescription tileDescription) {
                        GameMenu.Ins.SetTileDescriptionForStandalong(tileDescription.TileDescription);
                    } else {
                        GameMenu.Ins.SetTileDescriptionForStandalong(Localization.Ins.Get(tile.GetType()));
                    }

                    theTileToBeTapped = tile;
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                if (onSameTile) {

                    // 在非编辑器模式下，捕捉报错，并且
                    if (GameMenu.IsInEditor) {
                        OnTap(nowInt);
                    } else {
                        try {
                            OnTap(nowInt);
                        } catch (Exception e) {
                            UI.Ins.ShowItems("地块出现错误！！！", UIItem.CreateText(e.GetType().Name), UIItem.CreateMultilineText(e.Message), UIItem.CreateMultilineText(e.StackTrace));
                            throw e;
                        }
                    }
                }
                if (GameMenu.IsInMobile) {
                    Indicator.SetActive(false);
                }
                Head.gameObject.SetActive(false);
                Tail.gameObject.SetActive(false);
            }
        }


        private Vector2Int MathVector2Floor(Vector2 vec) {
            return new Vector2Int((int)Mathf.Floor(vec.x), (int)Mathf.Floor(vec.y));
        }

        [SerializeField]
        private GameObject Indicator;
        private void UpdateIndicator(Vector2Int pos) {
            Indicator.transform.position = (Vector2)(pos) + new Vector2(0.5f, 0.5f);
        }


        private ITile theTileToBeTapped;

        // 按到gameMenu按钮时，临时禁用onTap。也许有执行顺序的bug
        public static bool InterceptInteractionOnce = false;


        private void OnTap(Vector2Int pos) {
            // UI 打开时，禁用OnTap
            if (UI.Ins.Active) {
                return;
            }
            // GameMenu 点击时，禁用OnTap
            if (InterceptInteractionOnce) {
                InterceptInteractionOnce = false;
                return;
            }

            // 被Tap的地图
            IMapDefinition map = TheOnlyActiveMap as IMapDefinition;
            if (map == null) throw new Exception();
            // 被Tap的地块
            ITile tile = map.Get(pos.x, pos.y);
            if (tile == null) throw new Exception();
            // 被Tap的地块，若可运行
            IRunnable runable = tile as IRunnable;

            // 快捷方式
            GameMenu.ShortcutMode CurrentMode = GameMenu.Ins.CurrentShortcutMode;
            // 快捷方式参数
            Type shortcutType = UIItem.ShortcutType;

            // 地图默认类型
            Type defaultTileType = map.DefaultTileType;
            // 地块是否属于地图默认类型
            bool tileIsDefaultTileType = defaultTileType.IsAssignableFrom(tile.GetType());


            // 大部分简单工具已经弃用了，一般使用多功能工具
            if (CurrentMode != GameMenu.ShortcutMode.None) {
                // 无视工具的条件。目前询问tile
                IIgnoreTool ignoreTool = tile as IIgnoreTool;
                if (ignoreTool == null || !ignoreTool.IgnoreTool) {
                    switch (CurrentMode) {
                        // 建造和拆除工具
                        case GameMenu.ShortcutMode.ConstructDestruct:
                            // 如果是TerrainDefault，并且有快捷方式
                            if (tileIsDefaultTileType && shortcutType != null) {
                                // 如果能造，则造
                                if (map.CanUpdateAt(shortcutType, pos)) {
                                    map.UpdateAt(shortcutType, pos);
                                    tile.OnTapPlaySound();
                                }
                            }
                            // 如果是建筑
                            else {
                                // 如果可以停止，则停止
                                if (runable != null && !LinkUtility.HasAnyLink(tile)) {
                                    if (runable.CanStop()) runable.Stop();
                                }
                                // 如果可以拆除，则拆除
                                if (tile.CanDestruct()) {
                                    TheOnlyActiveMap.UpdateAt(defaultTileType, pos);
                                    tile.OnTapPlaySound();
                                }
                                // 无论是否拆除，复制建筑
                                UIItem.ShortcutType = tile.GetType(); // 复制
                            }
                            break;

                        // 物流工具，也常用于运行
                        case GameMenu.ShortcutMode.LinkUnlink:
                            if (!LinkUtility.HasAnyLink(tile)) {
                                // 如果没连接

                                // 尝试建立输入连接，有上下左右的优先顺序
                                LinkUtility.AutoConsume(tile);

                                // 如果能够运行，则运行。如果能停止，则停止
                                if (runable != null) {
                                    if (runable.Running) {
                                        if (runable.CanStop()) {
                                            runable.Stop();
                                            tile.OnTapPlaySound();
                                        }
                                    } else {
                                        if (runable.CanRun()) {
                                            runable.Run();
                                            tile.OnTapPlaySound();
                                        }
                                    }
                                }
                            } else {
                                // 如果有连接

                                // 如果能停止，则停止
                                if (runable != null && runable.CanStop()) {
                                    runable.Stop();
                                    tile.OnTapPlaySound();
                                }

                                // 如果能取消输出，先取消
                                LinkUtility.AutoProvide_Undo(tile);
                                // 如果能取消输入，则取消
                                LinkUtility.AutoConsume_Undo(tile);

                                // 如果上述操作过后，还有连接，说明？
                                if (LinkUtility.HasAnyLink(tile)) {
                                    LinkUtility.AutoConsume(tile);
                                }
                            }
                            break;
                    }
                }
            } else if (TheOnlyActiveMap.ControlCharacter && CharacterPositionInternal == pos) {
                GameMenu.Ins.OnTapPlayerInventory();
                tile.OnTapPlaySound();
            } else {
                map.OnTapTile(tile);
                tile.OnTapPlaySound();
            }
        }
    }
}

