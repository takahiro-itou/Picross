//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
/*************************************************************************
**                                                                      **
**                  ---  DocView Template Project  ---                  **
**                                                                      **
**          Copyright (C), 2017-2024, Takahiro Itou                     **
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

#include    "Sample/Common/SampleDocument.h"

#include    <iostream>

using   namespace   SAMPLE_NAMESPACE;

int  main(int argc, char * argv[])
{
    Sample::Common::SampleDocument  doc;

    std::string text("Hello, World!");

    doc.setMessage(text);
    std::cout   <<  "Text : "   <<  text
                <<  "\nThe number of alphabets in text:"
                <<  doc.countAlphabet()
                <<  std::endl;

    return ( 0 );
}
