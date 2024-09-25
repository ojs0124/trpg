using static TextRPG.WeaponItem;

namespace TextRPG
{
    class Player
    {
        public enum EClass { Warrior = 1, Fighter, Hunter, Sorcerer, Assassin }

        public int Level { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }

        public int TotalHP { get; set; }
        public int CurrentHP { get; set; }
        public int TotalMP { get; set; }
        public int CurrentMP { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Evasion { get; set; }

        public int Gold { get; set; }

        public Item inventory;

        public Player(string name)
        {
            this.Level = 1;
            this.Name = name;

            SelectClass();

            inventory = new Item();

            this.Gold = 1000;
        }

        void SelectClass()
        {
            Console.WriteLine("1.Warrior 2.Fighter 3.Hunter 4.Sorcerer 5.Assassin");
            Console.Write("플레이어 직업 선택: ");

            int classNumber = int.Parse(Console.ReadLine());
            EClass className = (EClass)classNumber;

            switch (className)
            {
                case EClass.Warrior:
                    this.Class = "Warrior";
                    SetAbility(150, 50, 10, 5, 3, 3);
                    break;

                case EClass.Fighter:
                    this.Class = "Fighter";
                    SetAbility(130, 70, 7, 7, 4, 5);
                    break;

                case EClass.Hunter:
                    this.Class = "Hunter";
                    SetAbility(120, 70, 11, 4, 5, 2);
                    break;

                case EClass.Sorcerer:
                    this.Class = "Sorcerer";
                    SetAbility(80, 120, 15, 3, 2, 2);
                    break;

                case EClass.Assassin:
                    this.Class = "Assassin";
                    SetAbility(100, 60, 8, 5, 7, 6);
                    break;
            }
        }

        void SetAbility(int hp, int mp, int attack, int defense, int speed, int evasion)
        {
            this.TotalHP = hp;
            this.CurrentHP = hp;
            this.TotalMP = mp;
            this.CurrentMP = mp;

            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.Evasion = evasion;
        }

        public int itemCount = 0;
        public void BuyItem(int num, Item itemStore)
        {
            itemCount++;

            foreach(WeaponItem weaponItem in itemStore.weapons)
            {
                if(num == weaponItem.itemNumber)
                {
                    if(this.Gold >= weaponItem.itemPrice)
                    {
                        WeaponItem weapon = weaponItem;
                        weapon.itemNumber = itemCount;
                        this.Gold -= weapon.itemPrice;
                        inventory.weapons.Add(weapon);
                        Console.WriteLine($"{weapon.itemName} 구매 완료");
                    }
                    else
                    {
                        Console.WriteLine("Gold 부족");
                    }
                }
            }

            foreach (ArmorItem armorItem in itemStore.armors)
            {
                if (num == armorItem.itemNumber)
                {
                    if (this.Gold >= armorItem.itemPrice)
                    {
                        ArmorItem armor = armorItem;
                        armor.itemNumber = itemCount;
                        this.Gold -= armor.itemPrice;
                        inventory.armors.Add(armor);
                        Console.WriteLine($"{armor.itemName} 구매 완료");
                    }
                    else
                    {
                        Console.WriteLine("Gold 부족");
                    }
                }
            }

            Thread.Sleep(1500);
        }

        public void SellItem(int num, Item inventory)
        {
            itemCount--;

            foreach (WeaponItem weaponItem in inventory.weapons)
            {
                if (num == weaponItem.itemNumber)
                {
                    this.Gold += weaponItem.itemPrice * 7 / 10;
                    inventory.weapons.Remove(weaponItem);
                    Console.WriteLine($"{weaponItem.itemName} 판매 완료");
                }
            }

            foreach (ArmorItem armorItem in inventory.armors)
            {
                if (num == armorItem.itemNumber)
                {
                    this.Gold += armorItem.itemPrice * 7 / 10;
                    inventory.armors.Remove(armorItem);
                    Console.WriteLine($"{armorItem.itemName} 판매 완료");
                }
            }

            Thread.Sleep(1500);
        }

        public void ManageItem(int num, Item inventory)
        {
            foreach (WeaponItem weaponItem in inventory.weapons)
            {
                if (num == weaponItem.itemNumber)
                {
                    if (weaponItem.itemName.Contains("[E]")){
                        weaponItem.itemName = weaponItem.itemName.Replace("[E]", "");
                        this.Attack -= weaponItem.itemAttack;
                    }
                    else
                    {
                        weaponItem.itemName = "[E]" + weaponItem.itemName;
                        this.Attack += weaponItem.itemAttack;
                    }
                }
            }

            foreach (ArmorItem armorItem in inventory.armors)
            {
                if (num == armorItem.itemNumber)
                {
                    armorItem.itemName = "[E]" + armorItem.itemName;
                    this.Defense += armorItem.itemDefense;
                }
            }
        }

        public void LevelUp()
        {
            this.Level += 1;

            this.TotalHP += 10;
            this.TotalMP += 4;
            this.CurrentHP = this.TotalHP;
            this.CurrentMP = this.TotalMP;

            this.Attack += 1;
            this.Defense += 1;
        }

        public void GetRest()
        {
            if(this.CurrentHP == this.TotalHP && this.CurrentMP == this.TotalMP)
            {
                Console.WriteLine("이미 HP, MP 모두 차있는 상태입니다.");
            }
            else
            {
                this.Gold -= 500;
                Console.WriteLine("500 gold를 사용하였습니다.");

                this.CurrentHP = (this.CurrentHP + 100 >= this.TotalHP) ? this.TotalHP : this.CurrentHP + 100;
                this.CurrentMP = (this.CurrentMP + 50 >= this.TotalMP) ? this.TotalMP : this.CurrentMP + 50;
                Console.WriteLine($"{this.Name}님이 휴식으로 100 HP와 50 MP를 회복하였습니다.");
            }
        }
    }
}
