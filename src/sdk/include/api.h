#pragma once

#if defined MNEMOSYNE_SDK_API_EXPORT
	#define MNEMOSYNE_SDK_API __declspec(dllexport)
#else
	#define MNEMOSYNE_SDK_API __declspec(dllimport)
#endif