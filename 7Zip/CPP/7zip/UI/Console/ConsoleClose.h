// ConsoleClose.h
//


#ifndef __CONSOLE_CLOSE_H
#define __CONSOLE_CLOSE_H

#if  defined(_WIN32)  || defined(_WIN64)

int __cdecl SevenZipExecute
(
	const wchar_t* args
);
#else
extern "C" {

	int __attribute__((__cdecl__)) SevenZipExecute(const wchar_t* args);

}
#endif //   defined(_WIN32)  || defined(_WIN64)
	



namespace NConsoleClose {

class CCtrlBreakException {};

#ifdef UNDER_CE

inline bool TestBreakSignal() { return false; }
struct CCtrlHandlerSetter {};

#else

extern unsigned g_BreakCounter;

inline bool TestBreakSignal()
{
  return (g_BreakCounter != 0);
}

class CCtrlHandlerSetter
{
  #ifndef _WIN32
  void (*memo_sig_int)(int);
  void (*memo_sig_term)(int);
  #endif
public:
  CCtrlHandlerSetter();
  virtual ~CCtrlHandlerSetter();
};

#endif

}

#endif
