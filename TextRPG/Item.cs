using static TextRPG.ArmorItem;
using static TextRPG.WeaponItem;

namespace TextRPG
{
    public enum ItemType { Weapon = 1, Armor, Accessories, Potion, }

    public interface IWearable
    {
        void Wear();
    }
    public interface IConsumable
    {
        void Consume();
    }
    public interface ISellable
    {
        void Sell();
    }

    public class WeaponItem : IWearable, ISellable
    {
        public enum WeaponTexture { Wood = 2, Steel = 5 }
        public enum WeaponCategory { Sword, Gauntlet, Pistol, Wand, Dagger }

        public int itemNumber { get; set; }
        public ItemType itemType = ItemType.Weapon;
        public string itemName { get; set; }
        public int itemAttack { get; set; }
        public int itemPrice { get; set; }

        public WeaponItem(int num, WeaponTexture weaponTexture, WeaponCategory weaponCategory)
        {
            itemNumber = num;
            itemName = weaponTexture.ToString() + " " + weaponCategory.ToString();
            itemAttack = (int)weaponTexture;

            if (weaponTexture == WeaponTexture.Wood)
            {
                itemPrice = (int)weaponTexture * 200;
            }
            else
            {
                itemPrice = (int)weaponTexture * 150;
            }
        }

        public void Wear()
        {

        }
        public void Sell()
        {

        }

        public int GetItemNumber() { return itemNumber; }
        public void GetInfo()
        {
            Console.Write($"{itemName} \t");
            if (itemName.Length < 12)
            {
                Console.Write("\t");
            }
            Console.Write($" | 공격력 +{itemAttack} \t");
            Console.WriteLine($" | {itemPrice} gold");
        }
    }

    public class ArmorItem : IWearable, ISellable
    {
        public enum ArmorTexture { Cloth = 1, Leather = 2, Chain = 4 }
        public enum ArmorParts { Head = 1, Top, Bottom, Gloves, Shoes }

        public int itemNumber { get; set; }
        public ItemType itemType = ItemType.Armor;
        public string itemName { get; set; }
        public int itemDefense { get; set; }
        public int itemParts { get; set; }
        public int itemPrice { get; set; }

        public ArmorItem(int num, ArmorTexture armorTexture, ArmorParts armorParts)
        {
            itemNumber = num;
            itemName = armorTexture.ToString() + " " + armorParts.ToString();
            itemDefense = (int)armorTexture;
            itemParts = (int)armorParts;
            itemPrice = (int)armorTexture * 100;
        }

        public void Wear()
        {

        }
        public void Sell()
        {

        }

        public int GetItemNumber() { return itemNumber; }
        public void GetInfo()
        {
            Console.Write($"{itemName} \t");
            if (itemName.Length < 12)
            {
                Console.Write("\t");
            }
            Console.Write($" | 방어력 +{itemDefense} \t");
            Console.WriteLine($" | {itemPrice} gold");
        }
    }

    public class AccessoriesItem : IWearable, ISellable
    {
        public enum AccessoriesParts { Necklace, Earring, Ring, Bracelet }

        int itemNumber { get; set; }

        ItemType itemType = ItemType.Accessories;

        public AccessoriesItem(int num, AccessoriesParts accessoriesParts)
        {

        }

        public void Wear()
        {

        }
        public void Sell()
        {

        }

        public void GetInfo()
        {

        }
    }

    public class ConsumeItem : IConsumable, ISellable
    {
        ItemType itemType = ItemType.Potion;

        public void Consume()
        {

        }
        public void Sell()
        {

        }

        public void GetInfo()
        {

        }
    }

    public class Item
    {
        public List<WeaponItem> weapons;
        public List<ArmorItem> armors;
        public List<ConsumeItem> consumes;

        public Item()
        {
            weapons = new List<WeaponItem>();
            armors = new List<ArmorItem>();
            consumes = new List<ConsumeItem>();
        }

        public Item(string str)
        {
            int itemNumber = 0;

            weapons = new List<WeaponItem>();
            foreach(WeaponTexture weaponTexture in Enum.GetValues(typeof(WeaponTexture)))
            {
                foreach (WeaponCategory weaponCategory in Enum.GetValues(typeof(WeaponCategory)))
                {
                    itemNumber++;
                    weapons.Add(new WeaponItem(itemNumber, weaponTexture, weaponCategory));
                }
            }

            armors = new List<ArmorItem>();
            foreach (ArmorTexture armorTexture in Enum.GetValues(typeof(ArmorTexture)))
            {
                foreach (ArmorParts armorParts in Enum.GetValues(typeof(ArmorParts)))
                {
                    itemNumber++;
                    armors.Add(new ArmorItem(itemNumber, armorTexture, armorParts));
                }
            }

            consumes = new List<ConsumeItem>();

        }

        public void GetWeaponItems()
        {
            foreach (WeaponItem weaponItem in weapons)
            {
                Console.Write($" - {weaponItem.itemNumber} ");
                weaponItem.GetInfo();
            }
        }

        public void GetArmorItems()
        {
            foreach (ArmorItem armorItem in armors)
            {
                Console.Write($" - {armorItem.itemNumber} ");
                armorItem.GetInfo();
            }
        }

        public void GetConsumeItems()
        {

        }

        public void GetAllItems()
        {
            foreach (WeaponItem weaponItem in weapons)
            {
                Console.Write(" - ");
                weaponItem.GetInfo();
            }

            foreach (ArmorItem armorItem in armors)
            {
                Console.Write(" - ");
                armorItem.GetInfo();
            }
        }
    }
}
