package com.app;

import com.app.Game;
import com.app.Character;
import java.util.List;
import jakarta.persistence.*;
import lombok.*;



@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@Entity
@Table(name = "\"NonPlayerCharacters\"")
public class NonPlayerCharacter extends Character {
	private static String[] attitudeStr = {"Friend", "Emeny"};

	@Column(name = "role")
	private String role = "Citizen";

	@Column(name = "attitude")
	private int attitude = 0;

	public NonPlayerCharacter(String name, int health, Game game) {
		super(name, health, game);
		//this.game = game;
	}

	public NonPlayerCharacter(String name, int health, String role, int attitude, Game game) {
		super(name, health, game);
		this.role = role;
		this.attitude = attitude;
		//this.game = game;
	}

	public void setAttitude(int attitude) {
		this.attitude = (attitude <= 0) ? 0 : 1;
	}

	public void panic() {
		System.out.printf("%s panics\n", name);
	}

	public void say(String what) {
		System.out.printf("%s said %s\n", name, what);
	}

	public void sleep(int hours) {
		System.out.printf("%s sleps %d hours\n", name, hours);
	}

	public void death() {
		System.out.printf("%s died\n", name);
	}

	public String toString() {
		return String.format("Name: '%s' Health: %d Role: '%s' Attitude: '%s' Game: '%s'", name, health, role, attitudeStr[attitude], game.getName());
	}
}