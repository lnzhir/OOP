package com.app;

import com.app.PlayerCharacter;
import com.app.NonPlayerCharacter;
import java.util.List;
import java.util.ArrayList;
import jakarta.persistence.*;
import lombok.*;


@Getter
@Setter
@NoArgsConstructor(access = AccessLevel.PRIVATE)
@Entity
@Table(name = "\"Levels\"")
public class Level {
	@Id   
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id", nullable = false)
	private int id;

	@Column(name = "name", length = 255)
	private String name;

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "pc_id")
	public PlayerCharacter playerCharacter;

	//@ManyToMany(mappedBy = "levels", fetch = FetchType.EAGER)
	@ManyToMany(fetch = FetchType.EAGER)
	@JoinTable(
		name = "\"LevelNPCs\""
		, joinColumns = @JoinColumn(name = "level_id")
		, inverseJoinColumns = @JoinColumn(name = "npc_id")
	)
	private List<NonPlayerCharacter> NPCs;

	@OneToMany(mappedBy = "level", orphanRemoval = true, cascade = CascadeType.ALL)
	//@OneToMany(cascade = CascadeType.ALL, orphanRemoval = true)
	//@JoinColumn(name = "level_id")
	private List<LevelNPC> levelNPCs;

	public Level(String name, PlayerCharacter playerCharacter) {
		this.name = name;
		this.playerCharacter = playerCharacter;
		NPCs = new ArrayList();
		levelNPCs = new ArrayList();
	}

	public String toString() {
		String npcStr = "";
		if (NPCs != null) {
			for (NonPlayerCharacter npc : NPCs) {
				npcStr += String.format("\t%s\n", npc.toString());
			}
		}
		
		return String.format("Name: '%s'\nPlayerCharacter:\n\t%s\nNonPlayerCharacters:\n%s",
			name, 
			playerCharacter.toString(),
			npcStr);
	}
}