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
**      プロジェクトの設定。
**
**      @file       Common/PicrossSettings.h
**/

#if !defined( PICROSS_CONFIG_INCLUDED_PICROSS_SETTINGS_H )
#    define   PICROSS_CONFIG_INCLUDED_PICROSS_SETTINGS_H

//  スクリプトによる設定値が書き込まれたヘッダを読み込む。  //
#if defined( PICROSS_USE_PRE_CONFIGURED_MSVC )
#    include    "Picross/.Config/PreConfigPicross.msvc.h"
#else
#    include    "Picross/.Config/ConfiguredPicross.h"
#endif

PICROSS_NAMESPACE_BEGIN

PICROSS_NAMESPACE_END

#endif
