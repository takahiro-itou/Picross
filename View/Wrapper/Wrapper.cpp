// This is the main DLL file.

#include "stdafx.h"

#include <msclr/marshal_cppstd.h>

#include "Wrapper.h"

#include <string>

namespace  PicrossWrapper  {
namespace  Common  {

//----------------------------------------------------------------
//    インスタンスを初期化する
//  （デフォルトコンストラクタ）。
//

PicrossDocument::PicrossDocument()
    : m_ptrObj { new WrapTarget() }
{
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （デストラクタ）。
//

PicrossDocument::~PicrossDocument()
{
    this->!PicrossDocument();
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （ファイナライザ）。
//

PicrossDocument::!PicrossDocument()
{
    if ( this->m_ptrObj ) {
        delete  this->m_ptrObj;
        this->m_ptrObj  = nullptr;
    }
}

//----------------------------------------------------------------
//    入力メッセージ中に含まれるアルファベットを数える。
//

int
PicrossDocument::countAlphabet()
{
    return ( this->m_ptrObj->countAlphabet() );
}

//----------------------------------------------------------------
//    メッセージを設定する。
//

void
PicrossDocument::setMessage(
        System::String^ message)
{
    std::string tmp = msclr::interop::marshal_as<std::string>(message);
    this->m_ptrObj->setMessage(tmp);
}

}   //  End of namespace  Common
}   //  End of namespace  PicrossWrapper
