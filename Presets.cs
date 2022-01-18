using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal static class Presets
    {
        internal static Dictionary<string, Preset> Values = populatePresets();

        private static Dictionary<string, Preset> populatePresets()
        {
            Dictionary<string, Preset> result = new Dictionary<string, Preset>();
            addPreset(result, new Preset(
                "Animate Objects: Tiny",
                new AttackSpecification(
                    "Slam" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    8 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                10 /* minionCount */));
            addPreset(result, new Preset(
                "Animate Objects: Small",
                new AttackSpecification(
                    "Slam" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                10 /* minionCount */));
            addPreset(result, new Preset(
                "Animate Objects: Medium",
                new AttackSpecification(
                    "Slam" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                5 /* minionCount */));
            addPreset(result, new Preset(
                "Animate Objects: Large",
                new AttackSpecification(
                    "Slam" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d10,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Animate Objects: Huge",
                new AttackSpecification(
                    "Slam" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    8 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d12,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Boar",
                new AttackSpecification(
                    "Tusk" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Constrictor Snake",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                new AttackSpecification(
                    "Constrict" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d8,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Elk",
                new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                /* Note: vs prone targets only */
                new AttackSpecification(
                    "Hooves" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    4 /* damageDieCount */,
                    DieType.d8,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Hunter Shark",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Blood Frenzy makes this likely */
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d8,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Plesiosaurus",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    3 /* damageDieCount */,
                    DieType.d6,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Polar Bear",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    5 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    5 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Rhinoceros",
                new AttackSpecification(
                    "Gore" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d8,
                    5 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Saber-Toothed Tiger",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d10,
                    5 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    5 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                1 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Brown Bears",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Dire Wolves",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Eagles",
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Hyenas",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Octopuses",
                new AttackSpecification(
                    "Tentacles" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Spiders",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Toads",
                /* Note: additional 1d10 poison damage! Need to represent that somehow! */
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d10,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Vultures",
                /* Note: additional 1d10 poison damage! Need to represent that somehow! */
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Lions",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Tigers",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d10,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                2 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Apes",
                new AttackSpecification(
                    "Fist" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    2 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                new AttackSpecification(
                    "Rock" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Black Bears",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Crocodiles",
                new AttackSpecification(
                    "Bite"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d10,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Goats",
                new AttackSpecification(
                    "Ram"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Sea Horses",
                new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Wasps",
                new AttackSpecification(
                    "Sting" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Reef Sharks",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Warhorses",
                new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                4 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Axe Beaks",
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Boars",
                new AttackSpecification(
                    "Tusk" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Constrictor Snakes",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Constrict" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Draft Horses",
                new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Elks",
                new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                new AttackSpecification(
                    "Hooves" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Badgers",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Bats",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Centipedes",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Frogs",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Lizards",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d8,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Owls",
                new AttackSpecification(
                    "Talons"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Poisonous Snakes",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    4 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Wolf Spiders",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Panthers",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Riding Horses",
                new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Wolves",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Blood Hawks",
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Camels",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Flying Snakes",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    3 /* damageDieCount */,
                    DieType.d4,
                    1 /* additionalDamage */, // Note: this is actually piercing
                    Resistance.None,
                    DamageType.Poison
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Crabs",
                new AttackSpecification(
                    "Claw" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Rats",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Weasels",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Mastiffs",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Mules",
                new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Poisonous Snakes",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    // TODO: add 2d4 poison on failed DC 10 CON save, or 1/2 that on success
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Ponies",
                new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    2 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Stirge",
                new AttackSpecification(
                    "Blood Drain" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    3 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Baboons",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    1 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    -1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Badgers",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Bats",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Cats",
                new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Crabs",
                new AttackSpecification(
                    "Claw" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Deer",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Eagles",
                new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    2 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Giant Fire Beetles",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    1 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    -1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Goats",
                new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Hawks",
                new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Hyenas",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    2 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d6,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Jackals",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    1 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    -1 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Lizards",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Octopuses",
                new AttackSpecification(
                    "Tentacles" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Bludgeoning
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Owls",
                new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Slashing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Quippers",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Rats",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Ravens",
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Scorpions",
                new AttackSpecification(
                    "Sting" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    // TODO: DC9 CON save, 1d8 poison damage on failure, or 1/2 on success
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Spiders",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    // TODO: DC9 CON save, 1d4 poison damage on failure
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Vultures",
                new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    2 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d4,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Weasels",
                new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    1 /* damageDieCount */,
                    DieType.d1,
                    0 /* additionalDamage */,
                    Resistance.None,
                    DamageType.Piercing
                    ),
                8 /* minionCount */));
            return result;
        }

        private static void addPreset(Dictionary<string, Preset> presets, Preset preset)
        {
            presets.Add(preset.Name, preset);
        }
    }
}
