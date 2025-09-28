package com.app;

import com.app.*;
import com.app.Menu.*;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.Option;
import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;


public class LevelMenu extends ClassMenu {

	public LevelMenu(JMenu parent) {
		super(parent, Level.class);
	}

	private Level inputLevel() {
		List<Level> levels = DBProvider.getAll(Level.class);
		for (int i = 0; i < levels.size(); i++) {
			System.out.printf("%d) %s\n", i, levels.get(i).getName());
		}
		return inputEntity(levels, "Level: ");
	}

	@Option(ordinal = 0, key = '1', description = "Весь список")
	public void list() {
		super.list();
	}

	@Option(ordinal = 1, key = '2', description = "Добавить уровень")
	public void add() {
		Scanner in = new Scanner(System.in);
		System.out.print("Name: ");
		String name = in.nextLine();
		//String name = System.console().readLine();

		PlayerCharacter player = inputEntity(PlayerCharacter.class, "PlayerCharacter: ");
		if (player != null) {
			Level level = new Level(name, player);
			player.getLevels().add(level);
			DBProvider.persist(level);
		}

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Добавить NPC в уровень")
	public void addNPC() {
		Level level = inputLevel();
		
		if (level != null) {
			NonPlayerCharacter npc = inputEntity(NonPlayerCharacter.class, "NonPlayerCharacter: ");
			if (npc != null) {
				DBProvider.transact(() -> {
					level.getNPCs().add(npc);
					npc.getLevels().add(level);
				});
			}
		}

		this.run();
	}

	@Option(ordinal = 3, key = '4', description = "Убрать NPC из уровня")
	public void deleteNPC() {
		Level level = inputLevel();

		if (level != null) {
			List<NonPlayerCharacter> npcs = level.getNPCs();
			if (npcs.size() != 0) {
				printList(npcs);
				NonPlayerCharacter npc = inputEntity(npcs, "NonPlayerCharacter: ");

				if (npc != null) {
					DBProvider.transact(() -> {
						npc.getLevels().remove(level);
						level.getNPCs().remove(npc);
					});

				}
			}
			else {
				System.out.println("Список NPC пуст");
			}
		}

		this.run();
	}

	@Option(ordinal = 4, key = '5', description = "Удалить уровень")
	public void delete() {
		Level level = inputLevel();
		if (level != null) {
			DBProvider.transact(() -> {
				for (PlayerCharacter player : DBProvider.getAll(PlayerCharacter.class)) {
					player.getLevels().remove(level);
				}

				for (NonPlayerCharacter npc : DBProvider.getAll(NonPlayerCharacter.class)) {
					npc.getLevels().remove(level);
				}

				level.getLevelNPCs().clear();
			});

			DBProvider.remove(level);
		}

		
		this.run();
	}

	@Option(ordinal = 5, key = '6', description = "Назад")
	public void back() {
		super.back();
	}
}