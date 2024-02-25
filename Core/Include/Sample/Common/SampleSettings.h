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
**      @file       Common/SampleSettings.h
**/

#if !defined( SAMPLE_CONFIG_INCLUDED_SAMPLE_SETTINGS_H )
#    define   SAMPLE_CONFIG_INCLUDED_SAMPLE_SETTINGS_H

//  スクリプトによる設定値が書き込まれたヘッダを読み込む。  //
#if defined( SAMPLE_USE_PRE_CONFIGURED_MSVC )
#    include    "Sample/.Config/PreConfigSample.msvc.h"
#else
#    include    "Sample/.Config/ConfiguredSample.h"
#endif

SAMPLE_NAMESPACE_BEGIN

SAMPLE_NAMESPACE_END

#endif
