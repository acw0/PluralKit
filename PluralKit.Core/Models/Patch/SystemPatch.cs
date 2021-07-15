#nullable enable
using System.Text.RegularExpressions;

namespace PluralKit.Core
{
    public class SystemPatch: PatchObject
    {
        public Partial<string?> Name { get; set; }
        public Partial<string?> Hid { get; set; }
        public Partial<string?> Description { get; set; }
        public Partial<string?> Tag { get; set; }
        public Partial<string?> AvatarUrl { get; set; }
        public Partial<string?> Color { get; set; }
        public Partial<string?> Token { get; set; }
        public Partial<string> UiTz { get; set; }
        public Partial<PrivacyLevel> DescriptionPrivacy { get; set; }
        public Partial<PrivacyLevel> MemberListPrivacy { get; set; }
        public Partial<PrivacyLevel> GroupListPrivacy { get; set; }
        public Partial<PrivacyLevel> FrontPrivacy { get; set; }
        public Partial<PrivacyLevel> FrontHistoryPrivacy { get; set; }
        public Partial<bool> PingsEnabled { get; set; }
        public Partial<int?> LatchTimeout { get; set; }
        public Partial<int?> MemberLimitOverride { get; set; }
        public Partial<int?> GroupLimitOverride { get; set; }

        public override UpdateQueryBuilder Apply(UpdateQueryBuilder b) => b
            .With("name", Name)
            .With("hid", Hid)
            .With("description", Description)
            .With("tag", Tag)
            .With("avatar_url", AvatarUrl)
            .With("color", Color)
            .With("token", Token)
            .With("ui_tz", UiTz)
            .With("description_privacy", DescriptionPrivacy)
            .With("member_list_privacy", MemberListPrivacy)
            .With("group_list_privacy", GroupListPrivacy)
            .With("front_privacy", FrontPrivacy)
            .With("front_history_privacy", FrontHistoryPrivacy)
            .With("pings_enabled", PingsEnabled)
            .With("latch_timeout", LatchTimeout)
            .With("member_limit_override", MemberLimitOverride)
            .With("group_limit_override", GroupLimitOverride);

        public new void CheckIsValid()
        {
            if (AvatarUrl.Value != null && !MiscUtils.TryMatchUri(AvatarUrl.Value, out var avatarUri))
                throw new InvalidPatchException("avatar_url");
            if (Color.Value != null && (!Regex.IsMatch(Color.Value, "^[0-9a-fA-F]{6}$")))
                throw new InvalidPatchException("color");
        }

        protected bool Equals(SystemPatch other) => 
               Name.Equals(other.Name)
            && Hid.Equals(other.Hid)
            && Description.Equals(other.Description)
            && Tag.Equals(other.Tag)
            && AvatarUrl.Equals(other.AvatarUrl)
            && Color.Equals(other.Color)
            && Token.Equals(other.Token)
            && UiTz.Equals(other.UiTz)
            && DescriptionPrivacy.Equals(other.DescriptionPrivacy)
            && MemberListPrivacy.Equals(other.MemberListPrivacy)
            && GroupListPrivacy.Equals(other.GroupListPrivacy)
            && FrontPrivacy.Equals(other.FrontPrivacy)
            && FrontHistoryPrivacy.Equals(other.FrontHistoryPrivacy)
            && PingsEnabled.Equals(other.PingsEnabled)
            && LatchTimeout.Equals(other.LatchTimeout)
            && MemberLimitOverride.Equals(other.MemberLimitOverride)
            && GroupLimitOverride.Equals(other.GroupLimitOverride);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SystemPatch) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ Description.GetHashCode();
                hashCode = (hashCode * 397) ^ Tag.GetHashCode();
                hashCode = (hashCode * 397) ^ AvatarUrl.GetHashCode();
                hashCode = (hashCode * 397) ^ Token.GetHashCode();
                hashCode = (hashCode * 397) ^ UiTz.GetHashCode();
                hashCode = (hashCode * 397) ^ DescriptionPrivacy.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberListPrivacy.GetHashCode();
                hashCode = (hashCode * 397) ^ GroupListPrivacy.GetHashCode();
                hashCode = (hashCode * 397) ^ FrontPrivacy.GetHashCode();
                hashCode = (hashCode * 397) ^ FrontHistoryPrivacy.GetHashCode();
                hashCode = (hashCode * 397) ^ PingsEnabled.GetHashCode();
                return hashCode;
            }
        }
    }
}