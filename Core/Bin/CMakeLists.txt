
set(project_common_libs
        ${PROJECT_NAME}-${LIBRARIES_TARGET_PREFIX}Common
)

add_executable       (ViewSample    ViewSample.cpp)
target_link_libraries(ViewSample    ${project_common_libs})

install(TARGETS         ViewSample
        DESTINATION     ${BINTOP_DIR_NAME}/
)
