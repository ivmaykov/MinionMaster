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
            string kParalyzingPoisonNote = "paralyzing poison, see stat block for effect details"; ;
            string kKnockedProneOnFailedSave = "target knocked prone on save failure";
            string k20FootChargeAndKnockedProneOnFailedSave = "requires 20 ft charge, " + kKnockedProneOnFailedSave;

            Dictionary<string, Preset> result = new Dictionary<string, Preset>();
            addPreset(result, new Preset(
                presetName: "Animate Objects: Tiny",
                minionName: "Object",
                attack1: new AttackSpecification(
                    name: "Slam",
                    isEnabled: true,
                    isMagical: false,
                    attackCount: 1,
                    advantage: Advantage.None,
                    hitModifier: 8,
                    damageFormula: DamageFormula.Parse("1d4+4"),
                    targetResistance: Resistance.None,
                    damageType: DamageType.Bludgeoning,
                    extraDamageSpecification: null
                    ),
                minionCount: 10));
            addPreset(result, new Preset(
                presetName: "Animate Objects: Small",
                minionName: "Object",
                attack1: new AttackSpecification(
                    name: "Slam",
                    isEnabled: true,
                    isMagical: false,
                    attackCount: 1,
                    advantage: Advantage.None,
                    hitModifier: 6,
                    damageFormula: DamageFormula.Parse("1d8+2"),
                    targetResistance: Resistance.None,
                    damageType: DamageType.Bludgeoning,
                    extraDamageSpecification: null
                    ),
                minionCount: 10));
            addPreset(result, new Preset(
                presetName: "Animate Objects: Medium",
                minionName: "Object",
                attack1: new AttackSpecification(
                    name: "Slam",
                    isEnabled: true,
                    isMagical: false,
                    attackCount: 1,
                    advantage: Advantage.None,
                    hitModifier: 5,
                    damageFormula: DamageFormula.Parse("2d6+1"),
                    targetResistance: Resistance.None,
                    damageType: DamageType.Bludgeoning,
                    extraDamageSpecification: null
                    ),
                minionCount: 5));
            addPreset(result, new Preset(
                presetName: "Animate Objects: Large",
                minionName: "Object",
                attack1: new AttackSpecification(
                    name: "Slam",
                    isEnabled: true,
                    isMagical: false,
                    attackCount: 1,
                    advantage: Advantage.None,
                    hitModifier: 6,
                    damageFormula: DamageFormula.Parse("2d10+2"),
                    targetResistance: Resistance.None,
                    damageType: DamageType.Bludgeoning,
                    extraDamageSpecification: null
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                presetName: "Animate Objects: Huge",
                minionName: "Object",
                attack1: new AttackSpecification(
                    name: "Slam",
                    isEnabled: true,
                    isMagical: false,
                    attackCount: 1,
                    advantage: Advantage.None,
                    hitModifier: 5,
                    damageFormula: DamageFormula.Parse("2d12+4"),
                    targetResistance: Resistance.None,
                    damageType: DamageType.Bludgeoning,
                    extraDamageSpecification: null
                    ),
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Boar" /* presetName */,
                "Giant Boar",
                attack1: new AttackSpecification(
                    "Tusk" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d6+3"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d6"),
                        damageType: DamageType.Slashing,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Constrictor Snake" /* presetName */,
                "Giant Constrictor Snake",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d6+4"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Constrict" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d8+4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 16,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 16 to escape"
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Giant Elk" /* presetName */,
                "Giant Elk",
                attack1: new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d6+4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d6"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 14,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                attack2: new AttackSpecification(
                    "Hooves (prone target only)" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("4d8+4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: false,
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Hunter Shark" /* presetName */,
                "Hunter Shark",
                attack1: new AttackSpecification(
                    "Bite (advantage vs wounded)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Blood Frenzy makes this likely */
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d8+4"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Plesiosaurus" /* presetName */,
                "Plesiosaurus",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("3d6+4"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Polar Bear" /* presetName */,
                "Polar Bear",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    DamageFormula.Parse("1d8+5"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    DamageFormula.Parse("2d6+5"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                true,
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Rhinoceros" /* presetName */,
                "Rhinoceros",
                attack1: new AttackSpecification(
                    "Gore" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    7 /* hitModifier */,
                    DamageFormula.Parse("2d8+5"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d8"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 15,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 2): Saber-Toothed Tiger" /* presetName */,
                "Saber-Toothed Tiger",
                attack1: new AttackSpecification(
                    "Bite (bonus action vs. prone)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("1d10+5"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d6+5"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 14,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 1));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Brown Bears" /* presetName */,
                "Brown Bear",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d4+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: true,
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Dire Wolves" /* presetName */,
                "Dire Wolf",
                attack1: new AttackSpecification(
                    "Bite (advantage with Pack Tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d6+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: kKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Eagles" /* presetName */,
                "Giant Eagle",
                attack1: new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d6+3"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: true,
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Hyenas" /* presetName */,
                "Giant Hyena",
                attack1: new AttackSpecification(
                    "Bite (bonus action Rampage, see stat block)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d6+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Octopuses" /* presetName */,
                "Giant Octopus",
                attack1: new AttackSpecification(
                    "Tentacles (grapples on hit)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d6+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 16,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 16 to escape"
                        )
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Spiders" /* presetName */,
                "Giant Spider",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d8+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d8"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 11,
                        DamageOnSaveFailure.Half,
                        note: kParalyzingPoisonNote
                        )
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Toads" /* presetName */,
                "Giant Toad",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d10+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("1d10"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Half,
                        note: "target grappled on hit (DC 13 to escape), allows Swallow attack, see stat block"
                        )
                    ),
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Giant Vultures" /* presetName */,
                "Giant Vulture",
                attack1: new AttackSpecification(
                    "Beak (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage /* pack tactics */,
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d4+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Talons (advantage with pack tactics)" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage /* pack tactics */,
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d6+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: true,
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Lions" /* presetName */,
                "Lion",
                attack1: new AttackSpecification(
                    "Bite (advantage with pack tactics, as bonus action vs. prone)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d8+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claw (advantage with pack tactics)" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1): Tigers" /* presetName */,
                "Tiger",
                attack1: new AttackSpecification(
                    "Bite (as bonus action vs prone)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d10+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d8+3"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 2));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Apes" /* presetName */,
                "Ape",
                attack1: new AttackSpecification(
                    "Fist" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    2 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Rock" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: false,
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Black Bears" /* presetName */,
                "Black Bear",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d4+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: true,
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Crocodiles" /* presetName */,
                "Crocodile",
                attack1: new AttackSpecification(
                    "Bite"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d10+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 12,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 12 to escape"
                        )
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Goats" /* presetName */,
                "Giant Goat",
                attack1: new AttackSpecification(
                    "Ram"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d4+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d4"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Sea Horses" /* presetName */,
                "Giant Sea Horse",
                attack1: new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d6"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Giant Wasps" /* presetName */,
                "Giant Wasp",
                attack1: new AttackSpecification(
                    "Sting" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("3d6"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 11,
                        DamageOnSaveFailure.Half,
                        note: kParalyzingPoisonNote
                        )
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Reef Sharks" /* presetName */,
                "Reef Shark",
                attack1: new AttackSpecification(
                    "Bite (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d8+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/2): Warhorses" /* presetName */,
                "Warhorse",
                attack1: new AttackSpecification(
                    "Hooves (as bonus action vs. prone)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d6+4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 14,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 4));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Axe Beaks" /* presetName */,
                "Axe Beak",
                attack1: new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d8+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Boars" /* presetName */,
                "Boar",
                attack1: new AttackSpecification(
                    "Tusk" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("1d6"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Constrictor Snakes" /* presetName */,
                "Constrictor Snake",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Constrict" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d8+2"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 14,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 14 to escape"
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Draft Horses" /* presetName */,
                "Draft Horse",
                attack1: new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("2d4+4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Elks" /* presetName */,
                "Elk",
                attack1: new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d6+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d6"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 13,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                attack2: new AttackSpecification(
                    "Hooves" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d4+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: false,
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Badgers" /* presetName */,
                "Giant Badger",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled - multiattack */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("2d4+1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                allowMultiAttack: true,
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Bats" /* presetName */,
                "Giant Bat",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Centipedes" /* presetName */,
                "Giant Centipede",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("3d6"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 11,
                        DamageOnSaveFailure.None,
                        note: kParalyzingPoisonNote
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Frogs" /* presetName */,
                "Giant Frog",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Half,
                        note: "target grappled on hit (DC 11 to escape), allows Swallow attack, see stat block"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Lizards" /* presetName */,
                "Giant Lizard",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d8+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Owls" /* presetName */,
                "Giant Owl",
                attack1: new AttackSpecification(
                    "Talons (Flyby)"  /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("2d6+1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Poisonous Snakes" /* presetName */,
                "Giant Poisonous Snake",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("1d4+4"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("3d6"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 11,
                        DamageOnSaveFailure.Half,
                        note: "poison bite"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Giant Wolf Spiders" /* presetName */,
                "Giant Wolf Spider",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d4+4"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d6"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 11,
                        DamageOnSaveFailure.Half,
                        note: kParalyzingPoisonNote
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Panthers" /* presetName */,
                "Panther",
                attack1: new AttackSpecification(
                    "Bite (as bonus action vs prone)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d6+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                attack2: new AttackSpecification(
                    "Claw" /* name */,
                    false /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 12,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                allowMultiAttack: false,
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Riding Horses" /* presetName */,
                "Riding Horse",
                attack1: new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("2d4+3"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/4): Wolves" /* presetName */,
                "Wolf",
                attack1: new AttackSpecification(
                    "Bite (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d4+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Full,
                        note: kKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Blood Hawks" /* presetName */,
                "Blood Hawk",
                attack1: new AttackSpecification(
                    "Beak (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Camels" /* presetName */,
                "Camel",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d4"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Flying Snakes" /* presetName */,
                "Flying Snake",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    6 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("3d4"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: false,
                        saveAbility: Ability.CON, // Doesn't matter
                        saveDC: 13, // Doesn't matter
                        damageOnSaveFailure: DamageOnSaveFailure.None /* doesn't matter */,
                        note: "no save poison bite"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Crabs" /* presetName */,
                "Giant Crab",
                attack1: new AttackSpecification(
                    "Claw" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 11 to escape, max 2 targets"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Rats" /* presetName */,
                "Giant Rat",
                attack1: new AttackSpecification(
                    "Bite (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Giant Weasels" /* presetName */,
                "Giant Weasel",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d4+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Mastiffs" /* presetName */,
                "Mastiff",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d6+1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 11,
                        DamageOnSaveFailure.Full,
                        note: kKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Mules" /* presetName */,
                "Mule",
                attack1: new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Poisonous Snakes" /* presetName */,
                "Poisonous Snake",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    // TODO: add 2d4 poison on failed DC 10 CON save, or 1/2 that on success
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("2d4"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 10,
                        DamageOnSaveFailure.Half,
                        note: "poison bite"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Ponies" /* presetName */,
                "Pony",
                attack1: new AttackSpecification(
                    "Hooves" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("2d4+2"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 1/8): Stirges" /* presetName */,
                "Stirge",
                attack1: new AttackSpecification(
                    "Blood Drain (see stat block for Attach mechanics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1d4+3"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Baboons" /* presetName */,
                "Baboon",
                attack1: new AttackSpecification(
                    "Bite (advantage with pack tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage /* Pack Tactics */,
                    1 /* hitModifier */,
                    DamageFormula.Parse("1d4-1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Badgers" /* presetName */,
                "Badger",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Bats" /* presetName */,
                "Bat",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Cats" /* presetName */,
                "Cat",
                attack1: new AttackSpecification(
                    "Claws" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Crabs" /* presetName */,
                "Crab",
                attack1: new AttackSpecification(
                    "Claw" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Deer" /* presetName */,
                "Deer",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    DamageFormula.Parse("1d4"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Eagles" /* presetName */,
                "Eagle",
                attack1: new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1d4+2"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Giant Fire Beetles" /* presetName */,
                "Giant Fire Beetle",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    1 /* hitModifier */,
                    DamageFormula.Parse("1d6-1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Goats" /* presetName */,
                "Goat",
                attack1: new AttackSpecification(
                    "Ram" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1d4+1"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("1d4"),
                        damageType: DamageType.Slashing,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 10,
                        DamageOnSaveFailure.Full,
                        note: k20FootChargeAndKnockedProneOnFailedSave
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Hawks" /* presetName */,
                "Hawk",
                attack1: new AttackSpecification(
                    "Talons" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Hyenas" /* presetName */,
                "Hyena",
                attack1: new AttackSpecification(
                    "Bite (advantage with Pack Tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    2 /* hitModifier */,
                    DamageFormula.Parse("1d6"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Jackals" /* presetName */,
                "Jackal",
                attack1: new AttackSpecification(
                    "Bite (advantage with Pack Tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    1 /* hitModifier */,
                    DamageFormula.Parse("1d4-1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Lizards" /* presetName */,
                "Lizard",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Octopuses" /* presetName */,
                "Octopus",
                attack1: new AttackSpecification(
                    "Tentacles" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Bludgeoning,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("0"),
                        damageType: DamageType.Bludgeoning,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.STR,
                        saveDC: 10,
                        DamageOnSaveFailure.Full,
                        note: "target grappled on hit, DC 10 to escape"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Owls" /* presetName */,
                "Owl",
                attack1: new AttackSpecification(
                    "Talons (Flyby)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    3 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Slashing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Quippers" /* presetName */,
                "Quipper",
                attack1: new AttackSpecification(
                    "Bite (advantage vs wounded)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage /* Blood Frenzy */,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Rats" /* presetName */,
                "Rat",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    0 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Ravens" /* presetName */,
                "Raven",
                attack1: new AttackSpecification(
                    "Beak" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Scorpions" /* presetName */,
                "Scorpion",
                attack1: new AttackSpecification(
                    "Sting" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    2 /* hitModifier */,
                    // TODO: DC9 CON save, 1d8 poison damage on failure, or 1/2 on success
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("1d8"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 9,
                        DamageOnSaveFailure.Half,
                        note: "poison sting"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Spiders" /* presetName */,
                "Spider",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    4 /* hitModifier */,
                    // TODO: DC9 CON save, 1d4 poison damage on failure
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    new ExtraDamageSpecification(
                        isMagical: false,
                        damageFormula: DamageFormula.Parse("1d4"),
                        damageType: DamageType.Poison,
                        targetResistance: Resistance.None,
                        requiresSave: true,
                        saveAbility: Ability.CON,
                        saveDC: 9,
                        DamageOnSaveFailure.Half,
                        note: "poison bite"
                        )
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Vultures" /* presetName */,
                "Vulture",
                attack1: new AttackSpecification(
                    "Beak (advantage with Pack Tactics)" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.Advantage, /* Note: Pack Tactics gives Advantage */
                    2 /* hitModifier */,
                    DamageFormula.Parse("1d4"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            addPreset(result, new Preset(
                "Conjure Animals (CR 0): Weasels" /* presetName */,
                "Weasel",
                attack1: new AttackSpecification(
                    "Bite" /* name */,
                    true /* isEnabled */,
                    false /* isMagical */,
                    1 /* attackCount */,
                    Advantage.None,
                    5 /* hitModifier */,
                    DamageFormula.Parse("1"),
                    Resistance.None,
                    DamageType.Piercing,
                    null /* extraDamageSpecification */
                    ),
                minionCount: 8));
            return result;
        }

        private static void addPreset(Dictionary<string, Preset> presets, Preset preset)
        {
            presets.Add(preset.PresetName, preset);
        }
    }
}
