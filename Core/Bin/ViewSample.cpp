//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
/*************************************************************************
**                                                                      **
**                  ---  Picross Solver  Core Lib  ---                  **
**                                                                      **
**          Copyright (C), 2024 Takahiro Itou                           **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

/**
**      ビューサンプルプログラム。
**
**      @file       Bin/ViewSample.cpp
**/

#include    "Picross/Common/PicrossDocument.h"

#include    <iostream>

using   namespace   PICROSS_NAMESPACE;

int  main(int argc, char * argv[])
{
    Common::PicrossDocument doc;

    std::string text("Hello, World!");

    doc.setMessage(text);
    std::cout   <<  "Text : "   <<  text
                <<  "\nThe number of alphabets in text:"
                <<  doc.countAlphabet()
                <<  std::endl;

    return ( 0 );
}
