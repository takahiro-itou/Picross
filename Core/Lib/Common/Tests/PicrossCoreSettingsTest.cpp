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
**      An Implementation of Test Case 'PicrossCoreSettings'.
**
**      @file       Common/Tests/PicrossCoreSettingsTest.cpp
**/

#include    "TestDriver.h"
#include    "Picross/Common/PicrossSettings.h"

PICROSS_NAMESPACE_BEGIN

//========================================================================
//
//    PicrossCoreSettingsTest  class.
//
/**
**    クラス PicrossCoreSettings の単体テスト。
**/

class  PicrossCoreSettingsTest : public  TestFixture
{
    CPPUNIT_TEST_SUITE(PicrossCoreSettingsTest);
    CPPUNIT_TEST(testNameSpace);
    CPPUNIT_TEST_SUITE_END();

public:
    virtual  void   setUp()     override    { }
    virtual  void   tearDown()  override    { }

private:
    void  testNameSpace();
};

CPPUNIT_TEST_SUITE_REGISTRATION( PicrossCoreSettingsTest );

//========================================================================
//
//    Tests.
//

void  PicrossCoreSettingsTest::testNameSpace()
{
    return;
}

PICROSS_NAMESPACE_END

//========================================================================
//
//    エントリポイント。
//

int  main(int argc, char * argv[])
{
    return ( executeCppUnitTests(argc, argv) );
}
