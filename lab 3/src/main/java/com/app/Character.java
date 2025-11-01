package com.app;

import com.app.Game;
import java.lang.Object;
import jakarta.persistence.*;
import lombok.*;



@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PROTECTED)
@MappedSuperclass
//@Inheritance(strategy = InheritanceType.TABLE_PER_CLASS )
public abstract class Character {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	protected int id;

	@Column(name = "name")
	protected String name = "";

	@Column(name = "health")
	protected int health = 1;

	protected Character(String name, int health, Game game) {
		this.name = name;
		this.health = health;
		this.game = game;
	}

	@ManyToOne
	@JoinColumn(name = "game_id")
	protected Game game;

	public abstract void sleep(int hours);
	public abstract void death();
}