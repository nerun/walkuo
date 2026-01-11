#!/bin/bash
ICO="walkuo.ico"
if [[ -f ../"$ICO" ]]; then
    rm ../"$ICO"
fi
IMG="walkuo-512.png"
convert "$IMG" -resize 256x256 icon-256.png
convert "$IMG" -resize 128x128 icon-128.png
convert "$IMG" -resize 64x64   icon-64.png
convert "$IMG" -resize 48x48   icon-48.png
convert "$IMG" -resize 32x32   icon-32.png
convert "$IMG" -resize 24x24   icon-24.png
convert "$IMG" -resize 16x16   icon-16.png
convert icon-256.png icon-128.png icon-64.png icon-48.png icon-32.png icon-24.png icon-16.png "$ICO"
rm icon-*
mv "$ICO" ../
