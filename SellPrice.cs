using BepInEx;
using HarmonyLib;

namespace SellPrice;
internal static class ModInfo {
    internal const string Guid = "air1068.elin.sellprice";
    internal const string Name = "SellPrice";
    internal const string Version = "0.1.0";
}

[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
class SellPrice : BaseUnityPlugin {
    private void Awake() {
        var harmony = new Harmony(ModInfo.Guid);
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(Thing), nameof(Thing.WriteNote))]
class Thing_WriteNote_Patch {
    static void Postfix(Thing __instance, UINote n) {
        n.AddText("Value: " + __instance.GetPrice(CurrencyType.Money, false, PriceType.Default, null).ToString(), FontColor.DontChange);
    }
}