using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HidePolicyIcons
{
    public class ModInfo : IUserMod
    {

        public string Description
        {
            get
            {
                return "Hides all the pesky district policy icons";
            }
        }

        public string Name
        {
            get
            {
                return "Hide Policy Icons";
            }
        }
    }

    public class Hidden : LoadingExtensionBase
    {
        private UITextureAtlas atlas = null;

        public override void OnLevelLoaded(LoadMode mode)
        {
            atlas = DistrictManager.instance.m_properties.m_areaIconAtlas;
            DistrictManager.instance.m_properties.m_areaIconAtlas = null;
            DistrictManager.instance.NamesModified();
        }

        public override void OnLevelUnloading()
        {
            if(atlas != null)
                DistrictManager.instance.m_properties.m_areaIconAtlas = atlas;
        }
    }
}
