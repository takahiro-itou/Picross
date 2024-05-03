//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
/*************************************************************************
**                                                                      **
**                  ---  DocView Template Project  ---                  **
**                                                                      **
**          Copyright (C), 2017-2021, Takahiro Itou                     **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

/**
**      プロジェクトの設定。
**
**      @file       Common/PicrossSettings.h
**/

#if !defined( SAMPLE_CONFIG_INCLUDED_SAMPLE_SETTINGS_H )
#    define   SAMPLE_CONFIG_INCLUDED_SAMPLE_SETTINGS_H

//  スクリプトによる設定値が書き込まれたヘッダを読み込む。  //
#if defined( PICROSS_USE_PRE_CONFIGURED_MSVC )
#    include    "Picross/.Config/PreConfigPicross.msvc.h"
#else
#    include    "Picross/.Config/ConfiguredPicross.h"
#endif

SAMPLE_NAMESPACE_BEGIN

SAMPLE_NAMESPACE_END

#endif
