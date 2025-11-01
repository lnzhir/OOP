package com.app.Menu;


import com.app.*;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.ExitOption;
import io.github.nickacpt.jmenu.annotations.Option;



public class MainMenu extends JMenu {
	private PCMenu pcMenu = new PCMenu(this);
	private NPCMenu npcMenu = new NPCMenu(this);
	private GameMenu gameMenu = new GameMenu(this);
	private PublisherMenu publisherMenu = new PublisherMenu(this);

	@Option(ordinal = 0, key = '1', description = "PlayerCharacters")
	public void players() {
		pcMenu.run();
	}

	@Option(ordinal = 1, key = '2', description = "NonPlayerCharacters")
	public void nonPlayers() {
		npcMenu.run();
	}

	@Option(ordinal = 2, key = '3', description = "Games")
	public void games() {
		gameMenu.run();
	}

	@Option(ordinal = 3, key = '4', description = "Publishers")
	public void publishers() {
		publisherMenu.run();
	}
	

	@Option(ordinal = 4, key = '5', description = "Выход")
	@ExitOption
	public void exit() {}
}