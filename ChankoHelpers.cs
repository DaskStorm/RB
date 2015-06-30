﻿using ff14bot.Enums;
using ff14bot.Managers;
using System.Collections.Generic;
using System.Linq;

namespace ChankoPlugin
{
    public static class Helpers
    {
        private static bool IsFoodItem(this BagSlot slot)
        {
            return (slot.Item.EquipmentCatagory == ItemUiCategory.Meal || slot.Item.EquipmentCatagory == ItemUiCategory.Ingredient);
        }

        public static IEnumerable<BagSlot> GetFoodItems(this IEnumerable<BagSlot> bags)
        {
            return bags
                .Where(s => s.IsFoodItem());
        }

        public static bool ContainsFooditem(this IEnumerable<BagSlot> bags, uint id)
        {
            return bags
                .Select(s => s.TrueItemId)
                .Contains(id);
        }

        public static BagSlot GetFoodItem(this IEnumerable<BagSlot> bags, uint id)
        {
            return bags.First(s => s.TrueItemId == id);
        }
    }
}
