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
**      スクリプトによる設定値が書き込まれるヘッダファイル。
**
**      @file       .Config/ConfiguredSample.h.in
**/

#if !defined( PICROSS_CONFIG_INCLUDED_PRE_CONFIGURED_PICROSS_H )
#    define   PICROSS_CONFIG_INCLUDED_CONFIGURED_PICROSS_H )

//========================================================================
//
//    Name Space.
//

/**
**    スクリプトによって設定された名前空間。
**/

#define     PICROSS_CNF_NS              Picross

/**
**    名前空間。
**/

#define     PICROSS_NAMESPACE           PICROSS_CNF_NS

#define     PICROSS_NAMESPACE_BEGIN     namespace  PICROSS_CNF_NS  {
#define     PICROSS_NAMESPACE_END       }


//========================================================================
//
//    Compiler Features.
//

//
//    キーワード constexpr  の検査。
//

#if ( 0 )
#    define     PICROSS_CORE_ENABLE_CONSTEXPR       1
#else
#    undef      PICROSS_CORE_ENABLE_CONSTEXPR
#endif

#if !defined( CONSTEXPR_VAR ) && !defined( CONSTEXPR_FUNC )
#    if ( PICROSS_CORE_ENABLE_CONSTEXPR )
#        define     CONSTEXPR_VAR       constexpr
#        define     CONSTEXPR_FUNC      constexpr
#    else
#        define     CONSTEXPR_VAR       const
#        define     CONSTEXPR_FUNC
#    endif
#endif

//
//    キーワード nullptr  の検査。
//

#if ( 1 )
#    define     PICROSS_CORE_ENABLE_NULLPTR         1
#else
#    if !defined( nullptr )
#        define     nullptr     NULL
#    endif
#    undef      PICROSS_CORE_ENABLE_NULLPTR
#endif

//
//    キーワード override の検査。
//

#if ( 1 )
#    define     PICROSS_CORE_ENABLE_OVERRIDE        1
#else
#    if !defined( override )
#        define     override
#    endif
#    undef      PICROSS_CORE_ENABLE_OVERRIDE
#endif

#endif
