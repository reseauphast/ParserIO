// “Copyright (C) 2009-2016 Association Réseau Phast”
// This file is part of ParserIO.
// ParserIO is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// ParserIO is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with ParserIO.  If not, see <http://www.gnu.org/licenses/>.
//
//For more information, please consult the ParserIO web site at
//<http://parserio.codeplex.com>
//
// test.cpp : Defines the entry point for the console application.
//
// 22/12/10 Version 1.0.0.0
// 22/12/10 DU [fr] Exemple d'utilisation de la méthode "variante"
//             [en] Use case example with the method "variante"

// TODO [fr] Méthodes supplementaires à supporter
//      [en] Supplementary methods to be supported
//
//      [fr] Permettre l'entrée par le clavier de la variable codeBar 
//      [en] Enable input bar code from keyboard
        

#include "stdafx.h"
#import "ParserIO.Core.tlb" named_guids raw_interfaces_only
using namespace ParserIO_Core;

int _tmain(int argc, _TCHAR* argv[])
{
/*
	HRESULT hr;
	hr = CoInitialize(NULL);

	IFunctionsPtr pIFunctions(__uuidof(Functions));
	
	BSTR codeBar = ::SysAllocString(L"+H3030605320CE0K");
	BSTR ret;

	if(hr == S_OK)
	{
	
		hr = pIFunctions->GetFullInformationSet(codeBar, &ret);

		if(hr == S_OK)
		{
			_tprintf(_T("result:%s\r\n"), ret);
		}
		else
		{
			_tprintf(_T("Call method:%s fail!\r\n"), _T("variante"));
		}
		
	}
	else
	{
		_tprintf(_T("Create COM object:%s fail!\r\n"), _T("ParserIO_Core"));
	}
	
	system("pause");
	::CoUninitialize();
	::SysFreeString(codeBar);
	*/
	return 0;
}