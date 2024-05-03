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
**      An Implementation of PicrossDocument class.
**
**      @file       Common/PicrossDocument.cpp
**/

#include    "Picross/Common/PicrossDocument.h"


PICROSS_NAMESPACE_BEGIN
namespace  Common  {

namespace  {

}   //  End of (Unnamed) namespace.


//========================================================================
//
//    PicrossDocument  class.
//

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
//    インスタンスを初期化する
//  （デフォルトコンストラクタ）。

PicrossDocument::PicrossDocument()
    : m_message()
{
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （デストラクタ）。
//

PicrossDocument::~PicrossDocument()
{
}

//========================================================================
//
//    Public Member Functions (Implement Pure Virtual).
//

//========================================================================
//
//    Public Member Functions (Overrides).
//

//========================================================================
//
//    Public Member Functions (Pure Virtual Functions).
//

//========================================================================
//
//    Public Member Functions (Virtual Functions).
//

//----------------------------------------------------------------
//    入力メッセージ中に含まれるアルファベットを数える。
//

int
PicrossDocument::countAlphabet()  const
{
    const   size_t  len = this->m_message.length();
    size_t  cnt = 0;
    for ( size_t i = 0; i < len; ++ i ) {
        const  char tmp = this->m_message[i];
        if ( ('A' <= tmp) && (tmp <= 'Z') ) {
            ++ cnt;
        } else if ( ('a' <= tmp) && (tmp <= 'z') ) {
            ++ cnt;
        }
    }

    return ( static_cast<int>(cnt) );
}

//========================================================================
//
//    Public Member Functions.
//

//========================================================================
//
//    Accessors.
//

//----------------------------------------------------------------
//    メッセージを設定する。

void
PicrossDocument::setMessage(
        const  std::string  &message)
{
    this->m_message = message;
}

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    For Internal Use Only.
//

}   //  End of namespace  Common
PICROSS_NAMESPACE_END
