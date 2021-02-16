﻿
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Weathering
{

    public interface IMapView
    {
        /// <summary>
        /// 设置和获取当前显示的地图。同时只会显示一个地图。
        /// </summary>
        IMap TheOnlyActiveMap { get; set; }

        Vector2 CameraPosition { get; set; }

        Color ClearColor { get; set; }

        float TappingSensitivityFactor { get; set; }
    }

    public class MapView : MonoBehaviour, IMapView
    {
        public static IMapView Ins { get; private set; }

        private void Awake() {
            if (Ins != null) throw new Exception();
            Ins = this;
#if !UNITY_EDITOR && !UNITY_STANDALONE
            Indicator.SetActive(false);
#endif
        }

        public IMap TheOnlyActiveMap { get; set; }

        public float CameraSize { 
            set {
                mainCamera.orthographicSize = value;
            } 
        }

        public Vector2 CameraPosition {
            get {
                return mainCamera.transform.position;
            }
            set {
                mainCamera.transform.position
                    = new Vector3(value.x, value.y,
                    mainCamera.transform.position.z);
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

        private int width;
        private int height;
        private void Update() {

            // 按下ESC键打开关闭菜单
#if UNITY_EDITOR || UNITY_STANDALONE
            CheckESCKey();
#endif

            width = TheOnlyActiveMap.Width;
            height = TheOnlyActiveMap.Height;
            UpdateInput();
            if (TheOnlyActiveMap != null) {
                if (!UI.Ins.Active) {
                    UpdateCameraWithTapping();
                }
                UpdateCameraWidthArrowKey();
                CorrectCameraPosition();
                UpdateMap();
                UpdateMapAnimation();
            }
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

        private float cameraSpeed = 10;
        private void UpdateCameraWidthArrowKey() {
            float ratio = cameraSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow)) {
                target = mainCamera.transform.position + Vector3.right * ratio;
                mainCamera.transform.position = target;
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                target = mainCamera.transform.position + Vector3.left * ratio;
                mainCamera.transform.position = target;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                target = mainCamera.transform.position + Vector3.up * ratio;
                mainCamera.transform.position = target;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                target = mainCamera.transform.position + Vector3.down * ratio;
                mainCamera.transform.position = target;
            }
        }

        public class TappingSensitivity { }

        public const float DefaultTappingSensitivity = 2f;
        public float TappingSensitivityFactor { get; set; } = 2f;
        private void UpdateCameraWithTapping() {
            if (!tapping) return;
            target = mainCamera.transform.position;
            Vector2 cameraDeltaDistance = deltaDistance * Time.deltaTime * TappingSensitivityFactor;
            target += (Vector3)cameraDeltaDistance;
            mainCamera.transform.Translate(cameraDeltaDistance);
        }

        private Vector3 target;
        private void CorrectCameraPosition() {

            target = mainCamera.transform.position;
            if (target.x > width / 2) {
                target.x -= width; ;
            }
            if (target.x < -width / 2) {
                target.x -= -width;
            }
            if (target.y > height / 2) {
                target.y -= height;
            }
            if (target.y < -height / 2) {
                target.y -= -height;
            }
            target.z = -17;
            mainCamera.transform.position = target;
        }

        public int CameraWidthHalf { private get; set; } = 11;
        public int CameraHeightHalf { private get; set; } = 8;
        private void UpdateMap() {

            Vector3 pos = mainCamera.transform.position;
            int x = (int)pos.x;
            int y = (int)pos.y;

            IRes res = Res.Ins;
            for (int i = x - CameraWidthHalf; i < x + CameraWidthHalf; i++) {
                for (int j = y - CameraHeightHalf; j < y + CameraHeightHalf; j++) {
                    ITileDefinition iTile = TheOnlyActiveMap.Get(i, j) as ITileDefinition;
                    // Tile tile = iTile == null ? null : Res.Ins.GetTile(iTile.SpriteKey);

                    Tile tileBase = null;
                    if (iTile.SpriteKeyBase != null && !res.TryGetTile(iTile.SpriteKeyBase, out tileBase)) {
                        throw new Exception($"Tile {iTile.SpriteKeyBase} not found for Tile {iTile.GetType().Name}");
                    }
                    Tile tile = null;
                    if (iTile.SpriteKey != null && !res.TryGetTile(iTile.SpriteKey, out tile)) {
                        throw new Exception($"Tile {iTile.SpriteKey} not found for Tile {iTile.GetType().Name}");
                    }
                    Tile tileOverlay = null;
                    if (iTile.SpriteKeyOverlay != null && !res.TryGetTile(iTile.SpriteKeyOverlay, out tileOverlay)) {
                        throw new Exception($"Tile {iTile.SpriteKeyOverlay} not found for Tile {iTile.GetType().Name}");
                    }

                    Tile tileLeft = null;
                    if (iTile.SpriteLeft != null && !res.TryGetTile(iTile.SpriteLeft, out tileLeft)) {
                        throw new Exception($"Tile {iTile.SpriteLeft} not found for Tile {iTile.GetType().Name}, in sprite left");
                    }
                    Tile tileRight = null;
                    if (iTile.SpriteRight != null && !res.TryGetTile(iTile.SpriteRight, out tileRight)) {
                        throw new Exception($"Tile {iTile.SpriteRight} not found for Tile {iTile.GetType().Name}, in sprite right");
                    }
                    Tile tileUp = null;
                    if (iTile.SpriteUp != null && !res.TryGetTile(iTile.SpriteUp, out tileUp)) {
                        throw new Exception($"Tile {iTile.SpriteUp} not found for Tile {iTile.GetType().Name}, in sprite up");
                    }
                    Tile tileDown = null;
                    if (iTile.SpriteDown != null && !res.TryGetTile(iTile.SpriteDown, out tileDown)) {
                        throw new Exception($"Tile {iTile.SpriteDown} not found for Tile {iTile.GetType().Name}, in sprite down");
                    }

                    Vector3Int pos3d = new Vector3Int(i, j, 0);
                    tilemapBase.SetTile(pos3d, tileBase);
                    tilemap.SetTile(pos3d, tile);
                    tilemapLeft.SetTile(pos3d, tileLeft);
                    tilemapRight.SetTile(pos3d, tileRight);
                    tilemapUp.SetTile(pos3d, tileUp);
                    tilemapDown.SetTile(pos3d, tileDown);
                    tilemapOverlay.SetTile(pos3d, tileOverlay);
                }
            }
        }

        private void UpdateMapAnimation() {
            double time = TimeUtility.GetSecondsInDouble();
            float fraction = (float)(time - (long)time);
            tilemapLeft.transform.position = Vector3.left * fraction;
            tilemapRight.transform.position = Vector3.right * fraction;
            tilemapUp.transform.position = Vector3.up * fraction;
            tilemapDown.transform.position = Vector3.down * fraction+Vector3.up;
        }

        [SerializeField]
        private Tilemap tilemap;
        [SerializeField]
        private Tilemap tilemapBase;
        [SerializeField]
        private Tilemap tilemapOverlay;
        [SerializeField]
        private Tilemap tilemapLeft;
        [SerializeField]
        private Tilemap tilemapRight;
        [SerializeField]
        private Tilemap tilemapUp;
        [SerializeField]
        private Tilemap tilemapDown;
        [SerializeField]
        private Camera mainCamera;



        private bool tapping;
        private Vector2 downRaw;
        private Vector2 down;
        private Vector2 deltaDistance;

        private readonly float deadZoneRadius = 0.2f;

        private void UpdateInput() {
            Vector3 mousePosition = Input.mousePosition;


            tapping = false;
            Vector2 now = mainCamera.ScreenToWorldPoint(mousePosition);
            if (Input.GetMouseButtonDown(0)) {
                downRaw = mousePosition;
                down = now;
            }
            if (Input.GetMouseButton(0)) {
                deltaDistance = now - (Vector2)mainCamera.ScreenToWorldPoint(downRaw);
                tapping = deltaDistance.sqrMagnitude > deadZoneRadius * deadZoneRadius;
            }

            // 这里与GameMenu or UI的那个按钮产生了强耦合，当点击位置在屏幕右上角时，不会考虑UpdateInput点击地块
            if (mousePosition.x > (Screen.width - 36 * 2) && mousePosition.y > (Screen.height - 36)) {
                return;
            }

            if (Input.GetMouseButtonUp(0)) {
                Vector2Int nowInt = ToVector2Int(now);
                if (nowInt == ToVector2Int(down)) {
                    OnTap(nowInt);
                }
            }

#if UNITY_EDITOR
            if (!UI.Ins.Active) {
                UpdateIndicator(ToVector2Int(now));
            }
#endif
        }

        private void OnTap(Vector2Int pos) {
            if (UI.Ins.Active) {
                return;
            }
            // 点地图时
            // Sound.Ins.PlayDefaultSound();
            ITile tile = TheOnlyActiveMap.Get(pos.x, pos.y);
            tile?.OnTap();
            tile?.OnTapPlaySound();
        }
        private Vector2Int ToVector2Int(Vector2 vec) {
            return new Vector2Int((int)Mathf.Floor(vec.x), (int)Mathf.Floor(vec.y));
        }

        [SerializeField]
        private GameObject Indicator;
        private void UpdateIndicator(Vector2Int pos) {
            Indicator.transform.position = (Vector2)(pos) + new Vector2(0.5f, 0.5f);
        }

    }
}

