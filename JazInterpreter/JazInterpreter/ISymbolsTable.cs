﻿using System;
using System.Collections.Generic;

namespace JazInterpreter
{
	public interface ISymbolsTable
	{
		void buildSymbolTable (string[,] code);
	}
}
	