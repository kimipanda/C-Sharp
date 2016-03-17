HelloPanda(sum)
{
	Loop
	{
		; A_index : The built-in variable A_Index contains the number of the current loop iteration
		; sum : HelloPanda parameter

		if (A_index > sum)
			break 

		Msgbox, Hello Panda %A_index%
	}
}

CreateGui()
{
	Gui,Add,Button,x10 y20 w50 h30 gButton,버튼
	Gui,Show,x500 y500 w500 h200 , GUI
	return

	Button:
	Msgbox, Hello Panda
	return

	GuiClose:
	Exitapp
	return
}