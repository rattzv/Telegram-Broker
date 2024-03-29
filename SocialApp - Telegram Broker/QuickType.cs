﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickType
{
    public class ApiServices
    {
        public string sms_activate_ru { get; set; }
    }
    public class JsonGetUinames
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
    }
    public class JsonOnloadData
    {
        public string save_password { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
    public class Account
    {
        public string email { get; set; }
        public DateTime date_registration { get; set; }
        public DateTime date_last_payment { get; set; }
        public string subscription_status { get; set; }
        public string subscription_type { get; set; }
        public string renewal_counter { get; set; }
    }

    public partial class ParsingApi
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("restricted", NullValueHandling = NullValueHandling.Ignore)]
        public string? Restricted { get; set; }

        [JsonProperty("access_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessHash { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string? Username { get; set; }

        [JsonProperty("signatures", NullValueHandling = NullValueHandling.Ignore)]
        public string? Signatures { get; set; }

        [JsonProperty("read_inbox_max_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReadInboxMaxId { get; set; }

        [JsonProperty("read_outbox_max_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReadOutboxMaxId { get; set; }

        [JsonProperty("hidden_prehistory", NullValueHandling = NullValueHandling.Ignore)]
        public string? HiddenPrehistory { get; set; }

        [JsonProperty("bot_info", NullValueHandling = NullValueHandling.Ignore)]
        public List<BotInfo> BotInfo { get; set; }

        [JsonProperty("notify_settings", NullValueHandling = NullValueHandling.Ignore)]
        public NotifySettings NotifySettings { get; set; }

        [JsonProperty("can_set_stickers", NullValueHandling = NullValueHandling.Ignore)]
        public string? CanSetStickers { get; set; }

        [JsonProperty("stickerset", NullValueHandling = NullValueHandling.Ignore)]
        public Stickerset Stickerset { get; set; }

        [JsonProperty("can_view_participants", NullValueHandling = NullValueHandling.Ignore)]
        public string? CanViewParticipants { get; set; }

        [JsonProperty("can_set_username", NullValueHandling = NullValueHandling.Ignore)]
        public string? CanSetUsername { get; set; }

        [JsonProperty("participants_count", NullValueHandling = NullValueHandling.Ignore)]
        public string? ParticipantsCount { get; set; }

        [JsonProperty("pinned_msg_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? PinnedMsgId { get; set; }

        [JsonProperty("about", NullValueHandling = NullValueHandling.Ignore)]
        public Uri About { get; set; }

        [JsonProperty("can_view_stats", NullValueHandling = NullValueHandling.Ignore)]
        public string? CanViewStats { get; set; }

        [JsonProperty("online_count", NullValueHandling = NullValueHandling.Ignore)]
        public string? OnlineCount { get; set; }

        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public Photo Photo { get; set; }

        [JsonProperty("participants", NullValueHandling = NullValueHandling.Ignore)]
        public List<Participant> Participants { get; set; }
    }

    public partial class BotInfo
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? UserId { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty("commands", NullValueHandling = NullValueHandling.Ignore)]
        public List<Command> Commands { get; set; }
    }

    public partial class Command
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("command", NullValueHandling = NullValueHandling.Ignore)]
        public string? CommandCommand { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }
    }

    public partial class NotifySettings
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("show_previews", NullValueHandling = NullValueHandling.Ignore)]
        public string? ShowPreviews { get; set; }

        [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
        public string? Silent { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty("promoted_by", NullValueHandling = NullValueHandling.Ignore)]
        public PromotedBy PromotedBy { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string? Date { get; set; }

        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string? Role { get; set; }
    }

    public partial class PromotedBy
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string? Username { get; set; }

        [JsonProperty("verified", NullValueHandling = NullValueHandling.Ignore)]
        public string? Verified { get; set; }

        [JsonProperty("restricted", NullValueHandling = NullValueHandling.Ignore)]
        public string? Restricted { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public PromotedByStatus Status { get; set; }

        [JsonProperty("access_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessHash { get; set; }

        [JsonProperty("bot_nochats", NullValueHandling = NullValueHandling.Ignore)]
        public string? BotNochats { get; set; }
    }

    public partial class PromotedByStatus
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("was_online", NullValueHandling = NullValueHandling.Ignore)]
        public string? WasOnline { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string? Username { get; set; }

        [JsonProperty("verified", NullValueHandling = NullValueHandling.Ignore)]
        public string? Verified { get; set; }

        [JsonProperty("restricted", NullValueHandling = NullValueHandling.Ignore)]
        public string? Restricted { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public UserStatus Status { get; set; }

        [JsonProperty("access_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessHash { get; set; }

        [JsonProperty("bot_nochats", NullValueHandling = NullValueHandling.Ignore)]
        public string? BotNochats { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("bot_inline_placeholder", NullValueHandling = NullValueHandling.Ignore)]
        public string? BotInlinePlaceholder { get; set; }
    }

    public partial class UserStatus
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("was_online", NullValueHandling = NullValueHandling.Ignore)]
        public string? WasOnline { get; set; }

        [JsonProperty("expires", NullValueHandling = NullValueHandling.Ignore)]
        public string? Expires { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("file_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? FileId { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public string? Width { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public string? Height { get; set; }

        [JsonProperty("file_size", NullValueHandling = NullValueHandling.Ignore)]
        public string? FileSize { get; set; }

        [JsonProperty("mime_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? MimeType { get; set; }

        [JsonProperty("file_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FileName { get; set; }
    }

    public partial class Stickerset
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
        public string? Archived { get; set; }

        [JsonProperty("official", NullValueHandling = NullValueHandling.Ignore)]
        public string? Official { get; set; }

        [JsonProperty("masks", NullValueHandling = NullValueHandling.Ignore)]
        public string? Masks { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("access_hash", NullValueHandling = NullValueHandling.Ignore)]
        public string? AccessHash { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? ShortName { get; set; }

        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public Thumb Thumb { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public string? Count { get; set; }

        [JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
        public string? Hash { get; set; }
    }

    public partial class Thumb
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public string? W { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public string? H { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string? Size { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("dc_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? DcId { get; set; }

        [JsonProperty("volume_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? VolumeId { get; set; }

        [JsonProperty("local_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? LocalId { get; set; }

        [JsonProperty("secret", NullValueHandling = NullValueHandling.Ignore)]
        public string? Secret { get; set; }

        [JsonProperty("file_reference", NullValueHandling = NullValueHandling.Ignore)]
        public FileReference FileReference { get; set; }
    }

    public partial class FileReference
    {
        [JsonProperty("_", NullValueHandling = NullValueHandling.Ignore)]
        public string? Empty { get; set; }

        [JsonProperty("bytes", NullValueHandling = NullValueHandling.Ignore)]
        public string? Bytes { get; set; }
    }

    public partial class ParsingApi
    {
        public static ParsingApi FromJson(string? json) => JsonConvert.DeserializeObject<ParsingApi>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string? ToJson(this ParsingApi self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
