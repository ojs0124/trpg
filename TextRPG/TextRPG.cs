namespace TextRPG
{
    public class TextRPG()
    {
        public enum Action { Exit, State, Inventory, Store, Dungeon, Rest }

        Player player;
        Item itemStore = new Item("Make Items");

        public void GamePlay()
        {
            Console.Write("플레이어 이름 입력: ");
            player = new Player(Console.ReadLine());

            ActionPage();
        }

        public void ActionPage()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. State");
            Console.WriteLine("2. Inventory");
            Console.WriteLine("3. Store");
            Console.WriteLine("4. Dungeon");
            Console.WriteLine("5. Rest");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int actionNumber = int.Parse(Console.ReadLine());
            Action actionName = (Action)actionNumber;

            switch (actionName)
            {
                case Action.State:
                    StatePage();
                    break;
                case Action.Inventory:
                    InventoryPage();
                    break;
                case Action.Store:
                    StorePage();
                    break;
                case Action.Dungeon:
                    DungeonPage();
                    break;
                case Action.Rest:
                    RestPage();
                    break;
                default:
                    ExitGame();
                    break;
            }
        }

        public void StatePage()
        {
            Console.Clear();

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보를 확인할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Class} )");
            Console.WriteLine($"HP : {player.CurrentHP}, MP : {player.CurrentMP}");
            Console.WriteLine($"공격력 : {player.Attack}, 방어력 : {player.Defense}");
            Console.WriteLine($"속도 : {player.Speed}, 회피율 : {player.Evasion}");
            Console.WriteLine($"Gold : {player.Gold} gold");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            if (int.Parse(Console.ReadLine()) == 0)
            {
                ActionPage();
            }
        }

        public void InventoryPage()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            player.inventory.GetAllItems();
            Console.WriteLine();

            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                ManageInventory();
            }
            else
            {
                ActionPage();
            }
        }

        public void ManageInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            player.inventory.GetWeaponItems();
            player.inventory.GetArmorItems();
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("장착 또는 해제할 장비를 선택하거나 관리 창을 나갈 수 있습니다.");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber == 0)
            {
                InventoryPage();
            }
            else
            {
                player.ManageItem(inputNumber, player.inventory);
                InventoryPage();
            }
        }

        public void StorePage()
        {
            Console.Clear();

            Console.WriteLine("상점");
            Console.WriteLine("아이템 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} gold");
            Console.WriteLine();

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber == 1)
            {
                PurchaseStoreItem();
            }
            else if(inputNumber == 2)
            {
                SellInventoryItem();
            }
            else
            {
                ActionPage();
            }

        }

        public void PurchaseStoreItem()
        {
            Console.Clear();

            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 구매할 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} gold");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            itemStore.GetWeaponItems();
            itemStore.GetArmorItems();
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber == 0)
            {
                StorePage();
            }
            else
            {
                player.BuyItem(inputNumber, itemStore);
                StorePage();
            }
        }

        public void SellInventoryItem()
        {
            Console.Clear();

            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 판매할 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} gold");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            player.inventory.GetWeaponItems();
            player.inventory.GetArmorItems();
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber == 0)
            {
                StorePage();
            }
            else
            {
                player.SellItem(inputNumber, player.inventory);
                StorePage();
            }
        }

        public void DungeonPage()
        {
            Console.Clear();

            Console.WriteLine("던전");
            Console.WriteLine("이곳에서 던전으로 들어갈 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. 쉬운 던전 \t | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전 \t | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전 \t | 방어력 17 이상 권장");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int inputNumber = int.Parse(Console.ReadLine());
            if(inputNumber >= 1 && inputNumber <= 3)
            {
                DungeonResult(inputNumber);
                DungeonPage();
            }
            else
            {
                ActionPage();
            }
        }

        public void DungeonResult(int level)
        {
            int recommendedDefense = 0;
            if (level == 1)
            {
                recommendedDefense = 5;
            }
            else if (level == 2)
            {
                recommendedDefense = 11;
            }
            else if (level == 3)
            {
                recommendedDefense = 17;
            }

            Random random = new Random();

            bool isClear = false;
            int hpBeforeDungeon = player.CurrentHP;
            int goldBeforeDungeon = player.Gold;
            if (player.Defense < recommendedDefense)
            {
                player.CurrentHP /= 2;
            }
            else
            {
                isClear = true;
                player.LevelUp();
                player.CurrentHP -= random.Next(20, 35);
                if(level == 1)
                {
                    player.Gold += 1000;
                }
                else if(level == 2)
                {
                    player.Gold += 1700;
                }
                else if(level == 3)
                {
                    player.Gold += 2500;
                }
            }
            player.CurrentHP -= player.Defense - recommendedDefense;

            Console.Clear();

            Console.WriteLine("던전");
            Console.WriteLine();

            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {hpBeforeDungeon} -> {player.CurrentHP}");
            Console.WriteLine($"골드 {goldBeforeDungeon} -> {player.Gold}");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ReadLine();
        }

        public void RestPage()
        {
            Console.Clear();

            Console.WriteLine("휴식하기");
            Console.WriteLine("500 gold를 내면 체력을 회복할 수 있습니다.");
            Console.WriteLine($"보유 골드 : {player.Gold} gold");
            Console.WriteLine();

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                if (player.Gold >= 500)
                {
                    player.GetRest();
                }
                else
                {
                    Console.WriteLine("휴식에 필요한 Gold 부족");
                }

                Thread.Sleep(1500);
            }

            ActionPage();
        }

        public void ExitGame()
        {
            return;
        }
    }
}
