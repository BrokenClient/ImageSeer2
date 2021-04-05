import winshell
import PythonMagick
import os

#argv=['',r"C:\Users\ASUS\Desktop\12.jpg"]
target=winshell.desktop()+ "\\ShortCut.lnk"
ico_file=r"D:\Program Files\ImageSeer\jpg.ico"
"""
from PIL import Image
im = Image.open(argv[1])
size=''
if im.size[0]/256<im.size[1]/256:
    size=str(int(im.size[0]/im.size[1]*256))+'x256'
else:
    size='256x'+str(int(im.size[1]/im.size[0]*256))
print(size)
"""

if os.path.exists(target):
    os.remove(target)
if os.path.exists(ico_file):
    os.remove(ico_file)

img=PythonMagick.Image(r"D:\Program Files\ImageSeer\relay.jpg")
img.sample('256x256')
img.write(ico_file)
#print(dir(PythonMagick))

winshell.CreateShortcut(
        Path = target,
        Target = r"D:\Program Files\ImageSeer\ImageSeer.exe",
        Icon = (ico_file, 0))
        
