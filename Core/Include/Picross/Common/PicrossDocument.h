﻿//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
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
**      An Interface of PicrossDocument class.
**
**      @file       Common/PicrossDocument.h
**/

#if !defined( PICROSS_CONFIG_INCLUDED_PICROSS_DOCUMENT_H )
#    define   PICROSS_CONFIG_INCLUDED_PICROSS_DOCUMENT_H

#include    "PicrossSettings.h"

#include    <string>

PICROSS_NAMESPACE_BEGIN
namespace  Common  {

//========================================================================
//
//    PicrossDocument  class.
//

class  PicrossDocument
{

//========================================================================
//
//    Internal Type Definitions.
//

//========================================================================
//
//    Constructor(s) and Destructor.
//
public:

    //----------------------------------------------------------------
    /**   インスタンスを初期化する
    **  （デフォルトコンストラクタ）。
    **
    **/
    PicrossDocument();

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （デストラクタ）。
    **
    **/
    virtual  ~PicrossDocument();

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
public:

    //----------------------------------------------------------------
    /**   入力メッセージ中に含まれるアルファベットを数える。
    **
    **  @return     半角アルファベット [A-Za-z] の文字数
    **/
    virtual  int
    countAlphabet()  const;

//========================================================================
//
//    Public Member Functions.
//

//========================================================================
//
//    Accessors.
//
public:

    //----------------------------------------------------------------
    /**   メッセージを設定する。
    **
    **  @param [in] message   入力データ
    **  @return     void.
    **/
    void
    setMessage(
            const  std::string  &message);

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    For Internal Use Only.
//

//========================================================================
//
//    Member Variables.
//
private:

    std::string     m_message;

//========================================================================
//
//    Other Features.
//
public:
    //  テストクラス。  //
    friend  class   PicrossDocumentTest;
};

}   //  End of namespace  Common
PICROSS_NAMESPACE_END

#endif
