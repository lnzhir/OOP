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
@Table(name = "\"Games\"")
public class Game {
	@Id   
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id", nullable = false)
	private int id;

	@Column(name = "name", length = 255)
	private String name;

	@Column(name = "version")
	private String version;

	@ManyToOne(fetch = FetchType.EAGER)
	@JoinColumn(name = "publisher_id")
	private Publisher publisher;

	@OneToMany(mappedBy = "game", targetEntity = PlayerCharacter.class, cascade = CascadeType.ALL, orphanRemoval = true)
	private List<PlayerCharacter> PCs = new ArrayList();

	@OneToMany(mappedBy = "game", targetEntity = NonPlayerCharacter.class, cascade = CascadeType.ALL, orphanRemoval = true)
	private List<NonPlayerCharacter> NPCs = new ArrayList();


	public Game(String name, String version, Publisher publisher) {
		this.name = name;
		this.version = version;
		this.publisher = publisher;
	}

	public String toString() {
//		String npcStr = "";
//		for (NonPlayerCharacter npc : NPCs) {
//			npcStr += String.format("\t%s\n", npc.toString());
//		}
//		String pcStr = "";
//		for (PlayerCharacter pc : PCs) {
//			pcStr += String.format("\t%s\n", pc.toString());
//		}
//
//		return String.format("Name: '%s' Version: '%s'\nPlayerCharacters:\n%s\nNonPlayerCharacters:\n%s",
//			name,
//			version,
//			pcStr,
//			npcStr);
		return String.format("Name: '%s' Version: '%s'", name, version);
	}
}