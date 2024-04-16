#!/bin/bash  -x

mkdir  -p  .Config

/bin/bash  -x  setuplinks.sh

aclocal  -I  .Config  \
  &&  autoheader      \
  &&  automake  --add-missing  --copy  --foreign  \
  &&  autoconf
