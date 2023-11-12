# MyFirstProject
##一个简单的UI管理框架
###结构
- UIState
    - UI的基础,继承自Monobehaviour和IUIState,会自动得到CanvasGroup组件,并进行开启UI和关闭UI操作。
    - CanPushUIStack是一个公有字段,如果为ture则可加入UIStack中进行按层级打开和关闭的操作。
    - blockGroupFind阻塞group的寻找。如果一个UIState并不想被父Group来控制则选true来屏蔽group的寻找,比如一个提示窗口,其作为个UIGroup的子物体,但他并不想要作为一个UIState来进行状态切换。则开启blockGroupFind可阻塞Group寻找。
- UIGroup
    - 一个UI的组,本质是一个FSM可以管理一组UIState,本身继承于UIState所以可以作为State被其他UIGroup来调用。
    - 继承于IUIGroup,内有切换SwitchUI(name)和AddState(name,state)
    - 自动在子物体内寻找UIState并加入状态字典中。
- UIManager
    - UIState的管理者,会自动寻找所有的UIState,并关闭他们。
    - 是一个单例类,每次场景都会重新加载对应的UIState。
    - 通过GetTargetUIState<UIType>()来得到相应的UIState。
- UISystem
    - 所有的UI从此进行间接的打开和关闭操作。本代码统一使用的是typename作为key进行查找OpenTargetUIState<UIType>(),其会自动转换为key(typeof(Type).Name)并从UIManager中获取。
    - 内有UIStack栈,存储当前打开的层级UI。

    --嘿嘿--
