package com.app.Menu;

import com.app.*;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.Option;
import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;


public class GameMenu extends ClassMenu {

	public GameMenu(JMenu parent) {
		super(parent, Game.class);
	}

	public static Game inputGame() {
		List<Game> games = DBProvider.getAll(Game.class);
		for (int i = 0; i < games.size(); i++) {
			System.out.printf("%d) %s\n", i, games.get(i).getName());
		}
		return inputEntity(games, "Game: ");
	}

	@Option(ordinal = 0, key = '1', description = "Весь список")
	public void list() {
		super.list();
	}

	@Option(ordinal = 1, key = '2', description = "Добавить игру")
	public void add() {
		Scanner in = new Scanner(System.in);
		System.out.print("Name: ");
		String name = in.nextLine();
		System.out.print("Version: ");
		String version = in.nextLine();

		Publisher publisher = PublisherMenu.inputPublisher();
		if (publisher != null) {
			Game game = new Game(name, version, publisher);
			publisher.getGames().add(game);
			DBProvider.persist(game);
		}

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Изменить запись")
	public void update() {
		Game game = inputGame();

		if (game != null) {
			Scanner in = new Scanner(System.in);
			System.out.print("Name: ");
			String name = in.nextLine();
			System.out.print("Version: ");
			String version = in.nextLine();

			DBProvider.transact(() -> {
				game.setName(name);
				game.setVersion(version);
			});
		}

		this.run();
	}

	/*@Option(ordinal = 2, key = '3', description = "Добавить PC в игру")
	public void addPC() {
		Game game = inputGame();
		
		if (game != null) {
			PlayerCharacter pc = inputEntity(PlayerCharacter.class, "PlayerCharacter: ");
			if (pc != null) {
				DBProvider.transact(() -> game.getPCs().add(pc));
			}
		}

		this.run();
	}

	@Option(ordinal = 3, key = '4', description = "Убрать PC из игры")
	public void deletePC() {
		Game game = inputGame();

		if (game != null) {
			List<PlayerCharacter> pcs = game.getPCs();
			if (pcs.size() != 0) {
				printList(pcs);
				PlayerCharacter pc = inputEntity(pcs, "PlayerCharacter: ");

				if (pc != null) {
					DBProvider.transact(() -> game.getPCs().remove(pc));
				}
			}
			else {
				System.out.println("Список PC пуст");
			}
		}

		this.run();
	}


	@Option(ordinal = 4, key = '3', description = "Добавить NPC в игру")
	public void addNPC() {
		Game game = inputGame();
		
		if (game != null) {
			NonPlayerCharacter npc = inputEntity(NonPlayerCharacter.class, "NonPlayerCharacter: ");
			if (npc != null) {
				DBProvider.transact(() -> game.getNPCs().add(npc));
			}
		}

		this.run();
	}

	@Option(ordinal = 5, key = '4', description = "Убрать NPC из игры")
	public void deleteNPC() {
		Game game = inputGame();

		if (game != null) {
			List<NonPlayerCharacter> npcs = game.getNPCs();
			if (npcs.size() != 0) {
				printList(npcs);
				NonPlayerCharacter npc = inputEntity(npcs, "NonPlayerCharacter: ");

				if (npc != null) {
					DBProvider.transact(() -> game.getNPCs().remove(npc));
				}
			}
			else {
				System.out.println("Список NPC пуст");
			}
		}

		this.run();
	}*/

	@Option(ordinal = 3, key = '4', description = "Удалить игру")
	public void delete() {
		Game game = inputGame();
		if (game != null) {
			DBProvider.transact(() -> {
				game.getNPCs().clear();
				game.getPCs().clear();
				game.getPublisher().getGames().remove(game);
			});

			//DBProvider.remove(game);
		}

		
		this.run();
	}

	@Option(ordinal = 4, key = '5', description = "Назад")
	public void back() {
		super.back();
	}
}