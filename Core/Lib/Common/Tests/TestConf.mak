
##
##    List of Tests.
##

EXTRATESTS              =
TESTS                   =  \
        PicrossCoreSettingsTest  \
        PicrossDocumentTest      \
        ${EXTRATESTS}
##
##    Test Configurations.
##

TARGET_TESTEE_LIBRARY       +=  -lsampleCommon

DIST_NOINST_DATA_FILES      +=
DIST_NOINST_HEADER_FILES    +=
EXTRA_TEST_DRIVERS          +=
LIBRARY_TEST_DRIVERS        +=
SOURCE_TEST_DRIVERS         +=

##
##    Compile and Link Options.
##

TEST_CPPFLAGS_COMMON        +=
TEST_LDFLAGS_COMMON         +=

##
##    Test Programs.
##

PicrossCoreSettingsTest_SOURCES  =  PicrossCoreSettingsTest.cpp
PicrossDocumentTest_SOURCES      =  PicrossDocumentTest.cpp

