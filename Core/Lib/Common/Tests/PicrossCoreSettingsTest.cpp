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
**      An Implementation of Test Case 'SampleCoreSettings'.
**
**      @file       Common/Tests/SampleCoreSettingsTest.cpp
**/

#include    "TestDriver.h"
#include    "Picross/Common/PicrossSettings.h"

PICROSS_NAMESPACE_BEGIN

//========================================================================
//
//    SampleCoreSettingsTest  class.
//
/**
**    クラス SampleCoreSettings の単体テスト。
**/

class  SampleCoreSettingsTest : public  TestFixture
{
    CPPUNIT_TEST_SUITE(SampleCoreSettingsTest);
    CPPUNIT_TEST(testNameSpace);
    CPPUNIT_TEST_SUITE_END();

public:
    virtual  void   setUp()     override    { }
    virtual  void   tearDown()  override    { }

private:
    void  testNameSpace();
};

CPPUNIT_TEST_SUITE_REGISTRATION( SampleCoreSettingsTest );

//========================================================================
//
//    Tests.
//

void  SampleCoreSettingsTest::testNameSpace()
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
