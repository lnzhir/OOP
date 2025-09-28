#include <iostream>
#include <cstring>
#include <vector>
#include <conio.h>
#include <ctype.h>
#include <math.h>
#include <functional>

using namespace std;


#define EXP_COEFF 1000
#define CLRSCR() system("cls") //printf("\033[2J\033[H")

enum class Attitude {
	friendly = 0,
	enemy = 1
};
string AttitudeStr[] = {"Friend", "Enemy"};

int curTime = 0; // в часах


class Character {
public:
	int GetHealth() {
		return health;
	}

	string GetName() {
		return name;
	}

	void Spawn() {
		cout << name << " spawned\n";
	}

	void Heal() {
		cout << name << " was healed\n";
	}

	virtual void Death() = 0;
	virtual void Sleep(int hours) = 0;

	virtual void print() {}
protected:
	Character(string name, int health) : name(name), health(health) {
	}

private:
	string name;
	int health;
};

// Player character
class PlayerCharacter : public Character {
public:
	PlayerCharacter(string name, int health) : Character(name, health) {
	}

	PlayerCharacter(string name, int health, int level, int experience) : Character(name, health) {
		this->level = level;
		this->experience = experience;
	}

	int GetLevel() {
		return level;
	}

	int GetExperience() {
		return experience;
	}

	void AddExperience(int value) {
		cout << GetName() << " received " << value << " experience " << endl;
		experience += value;
		//cout << "curr exp = " << experience << " curr level = " << level << endl;
		
		int maxExp = EXP_COEFF*level;
		int n = 0;
		while (experience > maxExp) {
			n++;
			level++;
			experience -= maxExp;
			maxExp = EXP_COEFF*level;
		}
		if (n > 0) {
			cout << GetName() << " leveled up to " << level << endl;
		}

		// if (experience >= maxExp) {
		// 	level = floor(  ( sqrt(4*EXP_COEFF*(EXP_COEFF - EXP_COEFF) + EXP_COEFF*EXP_COEFF + 8*EXP_COEFF*experience) - 2*EXP_COEFF + EXP_COEFF )/(2*EXP_COEFF)  );

		// 	experience -= ((EXP_COEFF + EXP_COEFF*level)*level)/2;
		// 	LevelUp();
		// }
		//cout << "curr exp after = " << experience << " curr level after = " << level << endl;
	}

	void LevelUp() {
		level++;
		cout << GetName() << " leveled up to " << level << endl;
	}

	void Death() {
		cout << GetName() << " died\n";
		cout << " ------- game over -------\n";
	}

	void Sleep(int hours) {
		curTime = (curTime+hours)%24;
		cout << GetName() << " slept. Current time = " << curTime << "h" << endl;
	}

	void print() {
		cout << "PlayerCharacter" << endl;
		cout << "name: " << GetName() << endl;
		cout << "health: " << GetHealth() << endl;
		cout << "level: " << level << endl;
		cout << "experience: " << experience << endl;
		cout << endl;
	}
private:
	int level = 1;
	int experience = 0;
};

// Non-player character
class NonPlayerCharacter : public Character {
public:
	NonPlayerCharacter(string name, int health) : Character(name, health) {
		attitude = Attitude::friendly;
	}

	NonPlayerCharacter(string name, int health, Attitude attitude) : Character(name, health) {
		this->attitude = attitude;
	}

	NonPlayerCharacter(string name, int health, string role, Attitude attitude) : Character(name, health) {
		this->role = role;
		this->attitude = attitude;
		printRole = true;
	}

	string GetRole() {
		return role;
	}

	Attitude GetAttitude() {
		return attitude;
	}

	void SetRole(string newRole) {
		role = newRole;
	}

	void SetAttitude(Attitude newAttitude) {
		attitude = newAttitude;
	}

	void Say(string whatSay) {
		cout << GetName() << " said: " << whatSay << endl;
	}

	void Panic() {
		cout << GetName() << " panics" << endl;
	}

	void Death() {
		cout << GetName() << " died\n";
	}

	void Sleep(int hours) {
		cout << GetName() << " slept\n";
	}

	void print() {
		cout << "NonPlayerCharacter" << endl;
		cout << "name: " << GetName() << endl;
		cout << "health: " << GetHealth() << endl;
		if (printRole)
			cout << "role: " << role << endl;
		cout << "attitude: " << AttitudeStr[(int)attitude] << endl;
		cout << endl;
	}
private:
	string role;
	Attitude attitude;

	bool printRole = false;
};


struct MenuItem {
	string title;
	function<void()> action;
	MenuItem* parent = nullptr;
	vector<MenuItem> subMenu;

	MenuItem(vector<MenuItem> subMenu) : title(title), subMenu(subMenu) {
		for (MenuItem& i : this->subMenu)
			i.parent = this;
	}

	MenuItem(string title, function<void()> action) : title(title), action(action) {
	}

	MenuItem(string title, vector<MenuItem> subMenu, function<void()> action) : title(title), subMenu(subMenu), action(action) {
		for (MenuItem& i : this->subMenu)
			i.parent = this;
	}

	void AddMenuItem(MenuItem menuItem) {
		menuItem.parent = this;
		subMenu.push_back(menuItem);
	}
};


// Character* characters[] = {
// 	new PlayerCharacter("Me (player)", 100), 
// 	new NonPlayerCharacter("Joseph (bot)", 100, "citizen", Attitude::friendly)
// };
vector<Character*> characters;
Character* curChar = nullptr;
int punct = 0;
MenuItem* curMenu = nullptr;
MenuItem* pcMenu = nullptr;
MenuItem* npcMenu = nullptr;
//bool withRole = true;

MenuItem itemBack = MenuItem("Back", [](){
	curMenu = curMenu->parent;
	punct = 0;
});

MenuItem itemFunctions[] = {
	MenuItem("Spawn", [](){
		curChar->Spawn();
		system("pause");
	}),
	MenuItem("Healing", [](){
		curChar->Heal();
		system("pause");
	}),
	// переопределенные
	MenuItem("Death", [](){
		curChar->Death();
		system("pause");
	}),
	MenuItem("Sleep", [](){
		cout << "input sleep hours\n";
		int hours;
		//cin >> hours;
		scanf("%d", &hours);
		curChar->Sleep(hours);
		system("pause");
	})
};

MenuItem itemAttributes[] = {
	MenuItem("Name", [](){
		cout << "Name: " << curChar->GetName() << endl;
		system("pause");
	}),
	MenuItem("Health", [](){
		cout << "Health: " << curChar->GetHealth() << endl;
		system("pause");
	})
};

vector<MenuItem> pcMenuItems = {
	// общие
	itemFunctions[0], itemFunctions[1], itemFunctions[2], itemFunctions[3],
	// собственные
	MenuItem("LevelUp", [](){
		((PlayerCharacter*)curChar)->LevelUp();
		system("pause");
	}),
	MenuItem("Add experience\n", [](){
		cout << "input experience points\n";
		int exp;
		cin >> exp;
		((PlayerCharacter*)curChar)->AddExperience(exp);
		system("pause");
	}),
	// свойства
	itemAttributes[0], itemAttributes[1],
	MenuItem("Level", [](){
		cout << "Level: " << ((PlayerCharacter*)curChar)->GetLevel() << endl;
		system("pause");
	}),
	MenuItem("Experience\n", [](){
		cout << "Experience: " << ((PlayerCharacter*)curChar)->GetExperience() << endl;
		system("pause");
	}), itemBack
};

vector<MenuItem> npcMenuItems = {
	// общие
	itemFunctions[0], itemFunctions[1], itemFunctions[2], itemFunctions[3],
	// собственные
	MenuItem("Say", [](){
		cout << "input what should he say\n";
		string msg;
		cin >> msg;
		((NonPlayerCharacter*)curChar)->Say(msg);
		system("pause");
	}),
	MenuItem("Panic\n", [](){
		((NonPlayerCharacter*)curChar)->Panic();
		system("pause");
	}),
	// свойства
	itemAttributes[0], itemAttributes[1],
	MenuItem("Role", [](){
		cout << "Role: " << ((NonPlayerCharacter*)curChar)->GetRole() << endl;
		system("pause");
	}),
	MenuItem("Attitude\n", [](){
		cout << "Attitude: " << AttitudeStr[(int)((NonPlayerCharacter*)curChar)->GetAttitude()] << endl;
		system("pause");
	}), itemBack
};

vector<MenuItem> npcMenuItemsWithoutRole = {
	npcMenuItems[0], npcMenuItems[1], npcMenuItems[2], npcMenuItems[3], npcMenuItems[4], npcMenuItems[5], npcMenuItems[6], 
	npcMenuItems[7], npcMenuItems[9], npcMenuItems[10]
};

MenuItem menu = MenuItem(
	{
		MenuItem("Add player character",
			[](){
				cout << "Name: ";
				string name;
				cin >> name;
				cout << "Health: ";
				int health;
				cin >> health;
				cout << "Level: ";
				int level;
				cin >> level;
				cout << "Experience: ";
				int exp;
				cin >> exp;
				PlayerCharacter* pc = new PlayerCharacter(name, health, level, exp);
				characters.push_back(pc);
				pcMenu->AddMenuItem(MenuItem(name, pcMenuItems, [=](){
					curChar = (Character*)pc;
				}));
			}
		),
		MenuItem("Add non player character",
			[](){
				cout << "Name: ";
				string name;
				cin >> name;

				cout << "Health: ";
				int health;
				cin >> health;

				cout << "Input role? (y/n)\n";
				string role;
				string withRole;
				while (withRole != "y" and withRole != "n") {
					cin >> withRole;
					if (withRole == "y") {
						cout << "Role: ";
						cin >> role;
					}
				}
				
				cout << "Attitude: ";
				int attitude;
				cin >> attitude;
				attitude = attitude >= 1 ? 1 : 0;

				NonPlayerCharacter* npc = withRole == "y" ? 
					new NonPlayerCharacter(name, health, role, (Attitude)attitude) :
					new NonPlayerCharacter(name, health, (Attitude)attitude);
				characters.push_back(npc);

				npcMenu->AddMenuItem(MenuItem(name, withRole == "y" ? npcMenuItems : npcMenuItemsWithoutRole, [=](){
					curChar = (Character*)npc;
				}));
			}
		),
		MenuItem("Select player character", {itemBack}, [](){}),
		MenuItem("Select non player character", {itemBack}, [](){}),
		MenuItem("Print all", {}, [](){
			for (Character* ch : characters) {
				ch->print();
			}
			system("pause");
		}),
		MenuItem("Exit", [](){
			exit(0);
		})
	}
);

int main(int argc, char const *argv[])
{
	curMenu = &menu;
	pcMenu = &menu.subMenu[2];
	npcMenu = &menu.subMenu[3];

	system("cls");
	int ch;
	while (ch != 27) {
		CLRSCR();
		//printf("\0338"); // restore cursor
		int j = 0;
		for (MenuItem& i : curMenu->subMenu) {
			//if (punct == j)
			//	printf("\033[36m");
			//printf("%s\n\033[37m", i.title.c_str());
			if (punct == j)
				cout << "-> ";
			cout << i.title.c_str() << endl;
			j++;
		}

		ch = _getch();
		switch (ch) {
			case 13: // enter
			{
				CLRSCR();
				
				
				if (curMenu->subMenu[punct].subMenu.size() > 0) {
					if (curMenu->subMenu[punct].action) {
						curMenu->subMenu[punct].action();
					}
					curMenu = &curMenu->subMenu[punct];
					punct = 0;
					break;
				}
				if (curMenu->subMenu[punct].action) {
					curMenu->subMenu[punct].action();
				}
				
			}
			break;
			case 72: // вверх
			{
				punct = (punct == 0) ? curMenu->subMenu.size()-1 : (punct - 1) % curMenu->subMenu.size();
			}
			break;
			case 80: // вниз
			{
				punct = (punct + 1) % curMenu->subMenu.size();
			}
			break;
		}
	}

	

	return 0;
}