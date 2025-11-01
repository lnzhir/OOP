package com.app;

import com.app.*;
import java.util.List;
import java.util.ArrayList;
import jakarta.persistence.*;
import lombok.*;


@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@Entity
@Table(name = "\"Publishers\"")
public class Publisher {
	@Id   
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id", nullable = false)
	private int id;

	@Column(name = "name", length = 255)
	private String name;

	@Column(name = "country", length = 255)
	private String country;

	@OneToMany(mappedBy = "publisher", cascade = CascadeType.ALL, orphanRemoval = true)
	private List<Game> games = new ArrayList();

	public Publisher(int id) {
		this.id = id;
	}

	public Publisher(String name, String country) {
		this.name = name;
		this.country = country;
	}

	public String toString() {
		String gameStr = "";
		for (Game game : games) {
			gameStr += String.format("\tName: '%s' Version: '%s'\n", game.getName(), game.getVersion());
		}
		return String.format("id: %d Name: '%s' Country: '%s'\nGames:\n%s",
			id,
			name,
			country,
			gameStr);
	}
}