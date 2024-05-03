
##----------------------------------------------------------------
##
##    テストの設定。
##

add_test(NAME   PicrossCoreSettingsTest
    COMMAND  $<TARGET_FILE:PicrossCoreSettingsTest>
)

add_test(NAME   PicrossDocumentTest
    COMMAND  $<TARGET_FILE:PicrossDocumentTest>
)

##----------------------------------------------------------------
##
##    テストプログラムのビルド。
##

add_executable(PicrossCoreSettingsTest  PicrossCoreSettingsTest.cpp)
add_executable(PicrossDocumentTest      PicrossDocumentTest.cpp)
