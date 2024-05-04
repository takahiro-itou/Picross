// Wrapper.h

#pragma once

#include    "Picross/Common/PicrossDocument.h"

using namespace System;

namespace  PicrossWrapper  {
namespace  Common  {

//========================================================================
//
//    PicrossDocument  class.
//

public ref  class  PicrossDocument
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

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （ファイナライザ）。
    **
    **/
    !PicrossDocument();

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

//========================================================================
//
//    Public Member Functions.
//
public:

    //----------------------------------------------------------------
    /**   入力メッセージ中に含まれるアルファベットを数える。
    **
    **  @param [in] message   入力データ
    **  @return     半角アルファベット [A-Za-z] の文字数
    **/
    int
    countAlphabet();

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
            System::String^ message);

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

    typedef     Picross::Common::PicrossDocument    WrapTarget;

    WrapTarget  *   m_ptrObj;
};

}   //  End of namespace  Common
}   //  End of namespace  PicrossWrapper
