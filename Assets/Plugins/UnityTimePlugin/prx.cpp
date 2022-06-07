#include <stdio.h>
#include <kernel.h>
#include <moduleinfo.h>
#include <libsysmodule.h>
#include	<rtc.h>

#define PRX_EXPORT extern "C" __declspec (dllexport)

SCE_MODULE_INFO(UnityTimePlugin, SCE_MODULE_ATTR_NONE, 1, 1);

extern "C" int module_start(SceSize sz, const void* arg)
{
	return SCE_KERNEL_START_SUCCESS;
}

PRX_EXPORT long long getCurrentTick() {
	SceRtcTick tick;
	sceRtcGetCurrentTick(&tick);
	return tick.tick;
}

PRX_EXPORT  SceDateTime getCurrentClockLocalTime() {
	SceDateTime date;
	sceRtcGetCurrentClockLocalTime(&date); 
	return date;
}
