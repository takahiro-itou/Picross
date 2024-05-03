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
**      An Implementation of Test Case 'PicrossDocument'.
**
**      @file       Common/Tests/PicrossDocumentTest.cpp
**/

#include    "TestDriver.h"
#include    "Picross/Common/PicrossDocument.h"

PICROSS_NAMESPACE_BEGIN
namespace  Common  {

//========================================================================
//
//    PicrossDocumentTest  class.
//
/**
**    クラス PicrossDocument の単体テスト。
**/

class  PicrossDocumentTest : public  TestFixture
{
    CPPUNIT_TEST_SUITE(PicrossDocumentTest);
    CPPUNIT_TEST(testCtor);
    CPPUNIT_TEST(testCountAlphabet1);
    CPPUNIT_TEST(testCountAlphabet2);
    CPPUNIT_TEST(testCountAlphabet3);
    CPPUNIT_TEST_SUITE_END();

public:
    virtual  void   setUp()     override    { }
    virtual  void   tearDown()  override    { }

private:
    void  testCtor();
    void  testCountAlphabet1();
    void  testCountAlphabet2();
    void  testCountAlphabet3();

};

CPPUNIT_TEST_SUITE_REGISTRATION( PicrossDocumentTest );

//========================================================================
//
//    Tests.
//

void  PicrossDocumentTest::testCtor()
{
    PicrossDocument testee;

    return;
}

void  PicrossDocumentTest::testCountAlphabet1()
{
    PicrossDocument testee;

    testee.setMessage("abcXYZ123");
    CPPUNIT_ASSERT_EQUAL( 6, testee.countAlphabet() );

    testee.setMessage("123");
    CPPUNIT_ASSERT_EQUAL( 0, testee.countAlphabet() );

    testee.setMessage("abc");
    CPPUNIT_ASSERT_EQUAL( 3, testee.countAlphabet() );

    return;
}

void  PicrossDocumentTest::testCountAlphabet2()
{
    PicrossDocument testee;

    testee.setMessage("");
    CPPUNIT_ASSERT_EQUAL( 0, testee.countAlphabet() );

    return;
}


void  PicrossDocumentTest::testCountAlphabet3()
{
    PicrossDocument testee;

    CPPUNIT_ASSERT_EQUAL( 0, testee.countAlphabet() );

    return;
}

}   //  End of namespace  Common
PICROSS_NAMESPACE_END

//========================================================================
//
//    エントリポイント。
//

int  main(int argc, char * argv[])
{
    return ( executeCppUnitTests(argc, argv) );
}
