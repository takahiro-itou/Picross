
##----------------------------------------------------------------
##
##    テストの設定。
##

add_test(NAME   SampleCoreSettingsTest
    COMMAND  $<TARGET_FILE:SampleCoreSettingsTest>
)

add_test(NAME   SampleDocumentTest
    COMMAND  $<TARGET_FILE:SampleDocumentTest>
)

##----------------------------------------------------------------
##
##    テストプログラムのビルド。
##

add_executable(SampleCoreSettingsTest   SampleCoreSettingsTest.cpp)
add_executable(SampleDocumentTest       SampleDocumentTest.cpp)
