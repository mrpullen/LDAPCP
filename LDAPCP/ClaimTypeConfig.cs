﻿using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Claims;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF = System.Security.Claims;

namespace ldapcp
{
    /// <summary>
    /// Defines an attribute / claim type configuration
    /// </summary>
    public class ClaimTypeConfig : SPAutoSerializingObject, IEquatable<ClaimTypeConfig>
    {
        /// <summary>
        /// Name of the attribute in LDAP
        /// </summary>
        public string LDAPAttribute
        {
            get { return _LDAPAttribute; }
            set { _LDAPAttribute = value; }
        }
        [Persisted]
        private string _LDAPAttribute;

        /// <summary>
        /// Class of the attribute in LDAP, typically 'user' or 'group'
        /// </summary>
        public string LDAPClass
        {
            get { return _LDAPClass; }
            set { _LDAPClass = value; }
        }
        [Persisted]
        private string _LDAPClass;

        /// <summary>
        /// define the claim type associated with the attribute that must map the claim type defined in the sp trust
        /// for example "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
        /// </summary>
        public string ClaimType
        {
            get { return _ClaimType; }
            set { _ClaimType = value; }
        }
        [Persisted]
        private string _ClaimType;

        /// <summary>
        /// SPClaimEntityTypes enum that represents the type of permission (a user, a role, a security group, etc...)
        /// </summary>
        public string ClaimEntityType
        {
            get { return _ClaimEntityType; }
            set { _ClaimEntityType = value; }
        }
        [Persisted]
        private string _ClaimEntityType = SPClaimEntityTypes.User;

        /// <summary>
        /// When creating a PickerEntry, it's possible to populate entry with additional attributes stored in EntityData hash table
        /// </summary>
        public string EntityDataKey
        {
            get { return _EntityDataKey; }
            set { _EntityDataKey = value; }
        }
        [Persisted]
        private string _EntityDataKey;

        /// <summary>
        /// Set to true if the attribute should always be queried in LDAP even if it is not defined in the SP trust (typically displayName and cn attributes)
        /// </summary>
        public bool CreateAsIdentityClaim
        {
            get { return _CreateAsIdentityClaim; }
            set { _CreateAsIdentityClaim = value; }
        }
        [Persisted]
        private bool _CreateAsIdentityClaim = false;

        /// <summary>
        /// This attribute is not intended to be used or modified in your code
        /// </summary>
        internal string ClaimTypeMappingName
        {
            get { return _ClaimTypeMappingName; }
            set { _ClaimTypeMappingName = value; }
        }
        [Persisted]
        private string _ClaimTypeMappingName;

        /// <summary>
        /// Every claim value type is a string by default
        /// </summary>
        public string ClaimValueType
        {
            get { return _ClaimValueType; }
            set { _ClaimValueType = value; }
        }
        [Persisted]
        private string _ClaimValueType = WIF.ClaimValueTypes.String;

        /// <summary>
        /// This prefix is added to the value of the permission created. This is useful to add a domain name before a group name (for example "domain\group" instead of "group")
        /// </summary>
        public string ClaimValuePrefix
        {
            get { return _ClaimValuePrefix; }
            set { _ClaimValuePrefix = value; }
        }
        [Persisted]
        private string _ClaimValuePrefix;

        /// <summary>
        /// If set to true: permission created without LDAP lookup (possible if PrefixToBypassLookup is set and user typed this keyword in the input) should not contain the prefix (set in PrefixToAddToValueReturned) in the value
        /// </summary>
        public bool DoNotAddClaimValuePrefixIfBypassLookup
        {
            get { return _DoNotAddClaimValuePrefixIfBypassLookup; }
            set { _DoNotAddClaimValuePrefixIfBypassLookup = value; }
        }
        [Persisted]
        private bool _DoNotAddClaimValuePrefixIfBypassLookup;

        /// <summary>
        /// Set this to tell LDAPCP to validate user input (and create the permission) without LDAP lookup if it contains this keyword at the beginning
        /// </summary>
        public string PrefixToBypassLookup
        {
            get { return _PrefixToBypassLookup; }
            set { _PrefixToBypassLookup = value; }
        }
        [Persisted]
        private string _PrefixToBypassLookup;

        /// <summary>
        /// Set this property to customize display text of the permission with a specific LDAP attribute (different than LDAPAttributeName, that is the actual value of the permission)
        /// </summary>
        public string LDAPAttributeToShowAsDisplayText
        {
            get { return _LDAPAttributeToShowAsDisplayText; }
            set { _LDAPAttributeToShowAsDisplayText = value; }
        }
        [Persisted]
        private string _LDAPAttributeToShowAsDisplayText;

        /// <summary>
        /// Set to only return values that exactly match the user input
        /// </summary>
        public bool FilterExactMatchOnly
        {
            get { return _FilterExactMatchOnly; }
            set { _FilterExactMatchOnly = value; }
        }
        [Persisted]
        private bool _FilterExactMatchOnly = false;

        /// <summary>
        /// Set this property to set a specific LDAP filter
        /// </summary>
        public string AdditionalLDAPFilter
        {
            get { return _AdditionalLDAPFilter; }
            set { _AdditionalLDAPFilter = value; }
        }
        [Persisted]
        private string _AdditionalLDAPFilter;

        /// <summary>
        /// Set to true to show the display name of claim type in parenthesis in display text of permission
        /// </summary>
        public bool ShowClaimNameInDisplayText
        {
            get { return _ShowClaimNameInDisplayText; }
            set { _ShowClaimNameInDisplayText = value; }
        }
        [Persisted]
        private bool _ShowClaimNameInDisplayText = true;

        public ClaimTypeConfig()
        {
        }

        public ClaimTypeConfig CopyPersistedProperties()
        {
            return new ClaimTypeConfig()
            {
                _AdditionalLDAPFilter = this._AdditionalLDAPFilter,
                _ClaimEntityType = this._ClaimEntityType,
                _ClaimType = this._ClaimType,
                _ClaimValueType = this._ClaimValueType,
                _DoNotAddClaimValuePrefixIfBypassLookup = this._DoNotAddClaimValuePrefixIfBypassLookup,
                _FilterExactMatchOnly = this._FilterExactMatchOnly,
                _PrefixToBypassLookup = this._PrefixToBypassLookup,
                _LDAPAttribute = this._LDAPAttribute,
                _LDAPAttributeToShowAsDisplayText = this._LDAPAttributeToShowAsDisplayText,
                _LDAPClass = this._LDAPClass,
                _EntityDataKey = this._EntityDataKey,
                _ClaimTypeMappingName = this._ClaimTypeMappingName,
                _ClaimValuePrefix = this._ClaimValuePrefix,
                _CreateAsIdentityClaim = this._CreateAsIdentityClaim,
                _ShowClaimNameInDisplayText = this._ShowClaimNameInDisplayText,
            };
        }

        public bool Equals(ClaimTypeConfig other)
        {
            if (new ClaimTypeConfigSameConfig().Equals(this, other))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Implements collection
    /// </summary>
    public class ClaimTypeConfigCollection : ICollection<ClaimTypeConfig>
    {   // Follows article https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1?view=netframework-4.7.1

        /// <summary>
        /// Internal collection serialized in persisted object
        /// </summary>
        internal Collection<ClaimTypeConfig> innerCol;

        public int Count => innerCol.Count;

        public bool IsReadOnly => false;

        public ClaimTypeConfigCollection()
        {
            innerCol = new Collection<ClaimTypeConfig>();
        }

        public ClaimTypeConfig this[int index]
        {
            get { return (ClaimTypeConfig)innerCol[index]; }
            set { innerCol[index] = value; }
        }

        public void Add(ClaimTypeConfig item)
        {
            if (String.IsNullOrEmpty(item.LDAPAttribute) || String.IsNullOrEmpty(item.LDAPClass))
            {
                throw new InvalidOperationException($"Properties LDAPAttribute and LDAPClass are required");
            }

            if (item.CreateAsIdentityClaim && !String.IsNullOrEmpty(item.ClaimType))
            {
                throw new InvalidOperationException($"No claim type should be set if CreateAsIdentityClaim is set to true");
            }

            if (Contains(item, new ClaimTypeConfigSamePermissionMetadata()))
            {
                throw new InvalidOperationException($"Permission metadata '{item.EntityDataKey}' already exists in the collection for the LDAP class {item.LDAPClass}");
            }

            if (Contains(item, new ClaimTypeConfigSameClaimType()))
            {
                throw new InvalidOperationException($"Claim type '{item.ClaimType}' already exists in the collection");
            }

            if (Contains(item))
            {
                throw new InvalidOperationException($"This configuration with claim type '{item.ClaimType}' already exists in the collection");
            }

            innerCol.Add(item);
        }

        public void Clear()
        {
            innerCol.Clear();
        }

        /// <summary>
        /// Test equality based on ClaimTypeConfigSameConfig (default implementation of IEquitable<T> in ClaimTypeConfig)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ClaimTypeConfig item)
        {
            bool found = false;
            foreach (ClaimTypeConfig ct in innerCol)
            {
                if (ct.Equals(item))
                {
                    found = true;
                }
            }
            return found;
        }

        public bool Contains(ClaimTypeConfig item, EqualityComparer<ClaimTypeConfig> comp)
        {
            bool found = false;
            foreach (ClaimTypeConfig ct in innerCol)
            {
                if (comp.Equals(ct, item))
                {
                    found = true;
                }
            }
            return found;
        }

        public void CopyTo(ClaimTypeConfig[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i + arrayIndex] = innerCol[i];
            }
        }

        public bool Remove(ClaimTypeConfig item)
        {
            bool result = false;

            // Iterate the inner collection to find the box to be removed.
            for (int i = 0; i < innerCol.Count; i++)
            {
                ClaimTypeConfig curBox = (ClaimTypeConfig)innerCol[i];
                if (new ClaimTypeConfigSameConfig().Equals(curBox, item))
                {
                    innerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        public IEnumerator<ClaimTypeConfig> GetEnumerator()
        {
            return new ClaimTypeConfigEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ClaimTypeConfigEnumerator(this);
        }
    }

    public class ClaimTypeConfigEnumerator : IEnumerator<ClaimTypeConfig>
    {
        private ClaimTypeConfigCollection _collection;
        private int curIndex;
        private ClaimTypeConfig curBox;


        public ClaimTypeConfigEnumerator(ClaimTypeConfigCollection collection)
        {
            _collection = collection;
            curIndex = -1;
            curBox = default(ClaimTypeConfig);

        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                curBox = _collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public ClaimTypeConfig Current
        {
            get { return curBox; }
        }


        object IEnumerator.Current
        {
            get { return Current; }
        }

    }

    public class ClaimTypeConfigSameConfig : EqualityComparer<ClaimTypeConfig>
    {
        public override bool Equals(ClaimTypeConfig ct1, ClaimTypeConfig ct2)
        {
            if (String.Equals(ct1.ClaimType, ct2.ClaimType, StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(ct1.LDAPAttribute, ct2.LDAPAttribute, StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(ct1.LDAPClass, ct2.LDAPClass, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(ClaimTypeConfig ct)
        {
            string hCode = ct.ClaimType + ct.LDAPAttribute + ct.LDAPClass;
            return hCode.GetHashCode();
        }
    }

    public class ClaimTypeConfigSameClaimType : EqualityComparer<ClaimTypeConfig>
    {
        public override bool Equals(ClaimTypeConfig ct1, ClaimTypeConfig ct2)
        {
            if (String.Equals(ct1.ClaimType, ct2.ClaimType, StringComparison.InvariantCultureIgnoreCase) &&
                !String.IsNullOrEmpty(ct2.ClaimType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(ClaimTypeConfig ct)
        {
            string hCode = ct.ClaimType + ct.LDAPAttribute + ct.LDAPClass;
            return hCode.GetHashCode();
        }
    }

    public class ClaimTypeConfigSamePermissionMetadata : EqualityComparer<ClaimTypeConfig>
    {
        public override bool Equals(ClaimTypeConfig ct1, ClaimTypeConfig ct2)
        {
            if (!String.IsNullOrEmpty(ct2.EntityDataKey) &&
                String.Equals(ct1.EntityDataKey, ct2.EntityDataKey, StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(ct1.LDAPClass, ct2.LDAPClass, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(ClaimTypeConfig ct)
        {
            string hCode = ct.ClaimType + ct.LDAPAttribute + ct.LDAPClass;
            return hCode.GetHashCode();
        }
    }
}
