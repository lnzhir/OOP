package com.app.Menu;

import com.app.*;
import com.app.Menu.*;
import org.hibernate.Hibernate;
import io.github.nickacpt.jmenu.JMenu;
import io.github.nickacpt.jmenu.annotations.Option;
import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;


public class PublisherMenu extends ClassMenu {

	public PublisherMenu(JMenu parent) {
		super(parent, Publisher.class);
	}

	public static Publisher inputPublisher() {
		List<Publisher> publishers = DBProvider.getAll(Publisher.class);
		for (int i = 0; i < publishers.size(); i++) {
			System.out.printf("%d) %s\n", i, publishers.get(i).getName());
		}
		return inputEntity(publishers, "Publisher: ");
	}

	@Option(ordinal = 0, key = '1', description = "Весь список")
	public void list() {
		super.list();
	}

	@Option(ordinal = 1, key = '2', description = "Добавить издателя")
	public void add() {
		//Scanner in = new Scanner(System.in);
		System.out.print("Name: ");
		//String name = in.nextLine();
		String name = System.console().readLine();
		System.out.print("Country: ");
		String country = System.console().readLine();

		if (name != "" && country != "") {
			DBProvider.persist(new Publisher(name, country));
		}
		if (name == "") {
			System.out.println("Пустое имя");
		}
		if (country == "") {
			System.out.println("Пустая страна");
		}

		this.run();
	}

	@Option(ordinal = 2, key = '3', description = "Изменить запись")
	public void update() {
		Publisher publisher = inputPublisher();

		if (publisher != null) {
			Scanner in = new Scanner(System.in);
			System.out.print("Name: ");
			String name = in.nextLine();
			System.out.print("Country: ");
			String country = in.nextLine();

			DBProvider.transact(() -> {
				publisher.setName(name);
				publisher.setCountry(country);
			});
		}

		this.run();
	}

	@Option(ordinal = 3, key = '4', description = "Вывести по id")
	public void getById() {
		Scanner in = new Scanner(System.in);
		System.out.print("Введите id: ");
		int id = in.nextInt();


		Publisher publisher = DBProvider.getById(Publisher.class, id);

		if (publisher != null) {
			for (Game game : publisher.getGames()) {
				//System.out.printf("Name: '%s' Version: '%s'\n", game.getName(), game.getVersion());
				System.out.println(game);
			}
		}

		this.run();
	}

	@Option(ordinal = 4, key = '5', description = "Удалить")
	public void delete() {
		Publisher publisher = inputPublisher();

		if (publisher != null) {
			if (publisher.getGames().size() > 0) {
				/*DBProvider.transact(() -> {

				});*/

				DBProvider.remove(publisher);
			} else {
				System.out.println("Не удален. У издателя остались игры");
			}
			
		}

		
		this.run();
	}

	@Option(ordinal = 5, key = '6', description = "Назад")
	public void back() {
		super.back();
	}
}