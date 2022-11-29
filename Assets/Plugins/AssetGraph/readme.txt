//--------------------------------------------------------
// AssetGraph Free
// 2020 Rokugen Lab
// Version 1.0.0
//--------------------------------------------------------

Table Of Contents
1. Overview
2. How to use
3. Button description
4. Mouse operation
5. Key operation
6. Change log


1. Overview
AssetGraph is an asset data dependency analyzer. 

It provides a graphical view of the relationships between assets and provides 
support for visually understanding dependencies. 
For example, by checking the reference relationship between Material and 
Texture or Shader, or by checking the reference relationship between 
AnimatorController and AnimationClip graphically, you can immediately make 
decisions about project organization and asset modification, so productivity 
can be expected to improve.

It will also automatically start rebuilding dependencies when changes are made 
to the Project (you can also request a rebuild manually) 
Dependency rebuilding is done in the background of the editor, so you can use 
it without compromising the usability of Unity Editor. 

This free version is prepared so that you can easily try out the functions 
provided by AssetGraph. 
We hope that you will actually use it and try it out. 

The free version has the following restrictions 
-Prefab resource and Scene resource cannot be detected 
-Composite display by selecting multiple nodes is not possible 


2. How to use
  1. Unity menu [Window] - [AssetGraph]
  2. AssetGraph window will open and starting Analyze your asset dependencies.
  3. After the analysis, the dependency graph is displayed.

3. Button description
  [Refresh]        (Re)Analyze all dependencies.
  [Show All]       Show all dependency nodes.
  [Show Selection] Show only selection dependency nodes.
                   Sibling nodes that do not pass through the selected node are not displayed.
  [Reset View]     Reset zoom and scroll state.

4. Mouse operation
  [click node] Select node. you can add a selection by clicking with [ctrl] or [shift].
  [wheel]      Zoom in/out

5. Key operation
  [A] View whole
  [F] Focus selected node

6. Change log
  1.0.0
    -First release
