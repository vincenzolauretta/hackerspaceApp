using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HackerspaceApp.Models.SpaceApi013
{
    /// <summary>
    /// SpaceAPI 0.13
    /// </summary>
    public partial class SpaceApi013Model
    {
        /// <summary>
        /// The version of SpaceAPI your endpoint uses
        /// </summary>
        [JsonProperty("api")]
        public string Api { get; set; }

        /// <summary>
        /// Specifies options about caching of your SpaceAPI endpoint. Use this if you want to avoid
        /// hundreds/thousands of application instances crawling your status.
        /// </summary>
        [JsonProperty("cache", NullValueHandling = NullValueHandling.Ignore)]
        public Cache Cache { get; set; }

        /// <summary>
        /// URL(s) of webcams in your space
        /// </summary>
        [JsonProperty("cam", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Cam { get; set; }

        /// <summary>
        /// Contact information about your space. You must define at least one which is in the list
        /// of allowed values of the issue_report_channels field.
        /// </summary>
        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        /// <summary>
        /// Events which happened recently in your space and which could be interesting to the
        /// public, like 'User X has entered/triggered/did something at timestamp Z'
        /// </summary>
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public Event[] Events { get; set; }

        /// <summary>
        /// Feeds where users can get updates of your space
        /// </summary>
        [JsonProperty("feeds", NullValueHandling = NullValueHandling.Ignore)]
        public Feeds Feeds { get; set; }

        /// <summary>
        /// This array defines all communication channels where you want to get automated issue
        /// reports about your SpaceAPI endpoint from the revalidator. This field is meant for
        /// internal usage only and it should never be consumed by any app. At least one channel must
        /// be defined. Please consider that when using <samp>ml</samp> the mailing list moderator
        /// has to moderate incoming emails or add the sender email to the subscribers. If you don't
        /// break your SpaceAPI implementation you won't get any notifications ;-)
        /// </summary>
        [JsonProperty("issue_report_channels")]
        public string[] IssueReportChannels { get; set; }

        /// <summary>
        /// Position data such as a postal address or geographic coordinates
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// URL to your space logo
        /// </summary>
        [JsonProperty("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// Your project sites (links to GitHub, wikis or wherever your projects are hosted)
        /// </summary>
        [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Projects { get; set; }

        /// <summary>
        /// A list of radio shows that your hackerspace might broadcast.
        /// </summary>
        [JsonProperty("radio_show", NullValueHandling = NullValueHandling.Ignore)]
        public RadioShow[] RadioShow { get; set; }

        /// <summary>
        /// Data of various sensors in your space (e.g. temperature, humidity, amount of Club-Mate
        /// left, …). The only canonical property is the <em>temp</em> property, additional sensor
        /// types may be defined by you. In this case, you are requested to share your definition for
        /// inclusion in this specification.
        /// </summary>
        [JsonProperty("sensors", NullValueHandling = NullValueHandling.Ignore)]
        public Sensors Sensors { get; set; }

        /// <summary>
        /// The name of your space
        /// </summary>
        [JsonProperty("space")]
        public string Space { get; set; }

        /// <summary>
        /// A flag indicating if the hackerspace uses SpaceFED, a federated login scheme so that
        /// visiting hackers can use the space WiFi with their home space credentials.
        /// </summary>
        [JsonProperty("spacefed", NullValueHandling = NullValueHandling.Ignore)]
        public Spacefed Spacefed { get; set; }

        /// <summary>
        /// A collection of status-related data: actual open/closed status, icons, last change
        /// timestamp etc.
        /// </summary>
        [JsonProperty("state")]
        public State State { get; set; }

        /// <summary>
        /// A mapping of stream types to stream URLs. If you use other stream types make a <a
        /// href="https://github.com/spaceapi/schema/pulls" target="_blank">pull request</a> or
        /// prefix yours with <samp>ext_</samp>.
        /// </summary>
        [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
        public Stream Stream { get; set; }

        /// <summary>
        /// URL to your space website
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Specifies options about caching of your SpaceAPI endpoint. Use this if you want to avoid
    /// hundreds/thousands of application instances crawling your status.
    /// </summary>
    public partial class Cache
    {
        /// <summary>
        /// Cache update cycle. This field must match the basic regular expression
        /// <code>^[mhd]\.[0-9]{2}$</code>, where the first field specifies a unit of time
        /// (<code>m</code> for 1 minute, <code>h</code> for 1 hour, <code>d</code> for 1 day), and
        /// the second field specifies how many of this unit should be skipped between updates. For
        /// example, <samp>m.10</samp> means one updates every 10 minutes, <samp>h.03</samp> means
        /// one update every 3 hours, and <samp>d.01</samp> means one update every day.
        /// </summary>
        [JsonProperty("schedule")]
        public string Schedule { get; set; }
    }

    /// <summary>
    /// Contact information about your space. You must define at least one which is in the list
    /// of allowed values of the issue_report_channels field.
    /// </summary>
    public partial class Contact
    {
        /// <summary>
        /// E-mail address for contacting your space. If this is a mailing list consider to use the
        /// contact/ml field.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Facebook account URL.
        /// </summary>
        [JsonProperty("facebook", NullValueHandling = NullValueHandling.Ignore)]
        public string Facebook { get; set; }

        /// <summary>
        /// Foursquare ID, in the form <samp>4d8a9114d85f3704eab301dc</samp>.
        /// </summary>
        [JsonProperty("foursquare", NullValueHandling = NullValueHandling.Ignore)]
        public string Foursquare { get; set; }

        /// <summary>
        /// Google services.
        /// </summary>
        //[JsonProperty("google", NullValueHandling = NullValueHandling.Ignore)]
        //public string[] Google { get; set; }

        /// <summary>
        /// Identi.ca or StatusNet account, in the form <samp>yourspace@example.org</samp>
        /// </summary>
        [JsonProperty("identica", NullValueHandling = NullValueHandling.Ignore)]
        public string Identica { get; set; }

        /// <summary>
        /// URL of the IRC channel, in the form <samp>irc://example.org/#channelname</samp>
        /// </summary>
        [JsonProperty("irc", NullValueHandling = NullValueHandling.Ignore)]
        public string Irc { get; set; }

        /// <summary>
        /// A separate email address for issue reports (see the <em>issue_report_channels</em>
        /// field). This value can be Base64-encoded.
        /// </summary>
        [JsonProperty("issue_mail", NullValueHandling = NullValueHandling.Ignore)]
        public string IssueMail { get; set; }

        /// <summary>
        /// A public Jabber/XMPP multi-user chatroom in the form
        /// <samp>chatroom@conference.example.net</samp>
        /// </summary>
        [JsonProperty("jabber", NullValueHandling = NullValueHandling.Ignore)]
        public string Jabber { get; set; }

        /// <summary>
        /// Persons who carry a key and are able to open the space upon request. One of the fields
        /// irc_nick, phone, email or twitter must be specified.
        /// </summary>
        [JsonProperty("keymasters", NullValueHandling = NullValueHandling.Ignore)]
        public Keymaster[] Keymasters { get; set; }

        /// <summary>
        /// The e-mail address of your mailing list. If you use Google Groups then the e-mail looks
        /// like <samp>your-group@googlegroups.com</samp>.
        /// </summary>
        [JsonProperty("ml", NullValueHandling = NullValueHandling.Ignore)]
        public string Ml { get; set; }

        /// <summary>
        /// Phone number, including country code with a leading plus sign. Example: <samp>+1 800 555
        /// 4567</samp>
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// URI for Voice-over-IP via SIP. Example: <samp>sip:yourspace@sip.example.org</samp>
        /// </summary>
        [JsonProperty("sip", NullValueHandling = NullValueHandling.Ignore)]
        public string Sip { get; set; }

        /// <summary>
        /// Twitter handle, with leading @
        /// </summary>
        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }
    }

    /// <summary>
    /// Google services.
    /// </summary>
    public partial class Google
    {
        /// <summary>
        /// Google plus URL.
        /// </summary>
        [JsonProperty("plus", NullValueHandling = NullValueHandling.Ignore)]
        public string Plus { get; set; }
    }

    public partial class Keymaster
    {
        /// <summary>
        /// Email address which can be base64 encoded.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Contact the person with this nickname directly in irc if available. The irc channel to be
        /// used is defined in the contact/irc field.
        /// </summary>
        [JsonProperty("irc_nick", NullValueHandling = NullValueHandling.Ignore)]
        public string IrcNick { get; set; }

        /// <summary>
        /// Real name
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Example: <samp>['+1 800 555 4567','+1 800 555 4544']</samp>
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Twitter username with leading <samp>@</samp>.
        /// </summary>
        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }
    }

    public partial class Event
    {
        /// <summary>
        /// A custom text field to give more information about the event
        /// </summary>
        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        public string Extra { get; set; }

        /// <summary>
        /// Name or other identity of the subject (e.g. <samp>J. Random Hacker</samp>,
        /// <samp>fridge</samp>, <samp>3D printer</samp>, …)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Unix timestamp when the event occurred
        /// </summary>
        [JsonProperty("timestamp")]
        public double? Timestamp { get; set; }

        /// <summary>
        /// Action (e.g. <samp>check-in</samp>, <samp>check-out</samp>, <samp>finish-print</samp>,
        /// …). Define your own actions and use them consistently, canonical actions are not (yet)
        /// specified
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Feeds where users can get updates of your space
    /// </summary>
    public partial class Feeds
    {
        [JsonProperty("blog", NullValueHandling = NullValueHandling.Ignore)]
        public Blog Blog { get; set; }

        [JsonProperty("calendar", NullValueHandling = NullValueHandling.Ignore)]
        public Calendar Calendar { get; set; }

        [JsonProperty("flickr", NullValueHandling = NullValueHandling.Ignore)]
        public Flickr Flickr { get; set; }

        [JsonProperty("wiki", NullValueHandling = NullValueHandling.Ignore)]
        public Wiki Wiki { get; set; }
    }

    public partial class Blog
    {
        /// <summary>
        /// Type of the feed, for example <samp>rss</samp>, <samp>atom</atom>, <samp>ical</samp>
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Feed URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Calendar
    {
        /// <summary>
        /// Type of the feed, for example <samp>rss</samp>, <samp>atom</atom>, <samp>ical</samp>
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Feed URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Flickr
    {
        /// <summary>
        /// Type of the feed, for example <samp>rss</samp>, <samp>atom</atom>, <samp>ical</samp>
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Feed URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Wiki
    {
        /// <summary>
        /// Type of the feed, for example <samp>rss</samp>, <samp>atom</atom>, <samp>ical</samp>
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Feed URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Position data such as a postal address or geographic coordinates
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// The postal address of your space (street, block, housenumber, zip code, city, whatever
        /// you usually need in your country, and the country itself).<br>Examples: <ul><li>Netzladen
        /// e.V., Breite Straße 74, 53111 Bonn, Germany</li></ul>
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// Latitude of your space location, in degree with decimal places. Use positive values for
        /// locations north of the equator, negative values for locations south of equator.
        /// </summary>
        [JsonProperty("lat")]
        public double? Lat { get; set; }

        /// <summary>
        /// Longitude of your space location, in degree with decimal places. Use positive values for
        /// locations east of Greenwich, and negative values for locations west of Greenwich.
        /// </summary>
        [JsonProperty("lon")]
        public double? Lon { get; set; }
    }

    public partial class RadioShow
    {
        /// <summary>
        /// Specify the end time by using the <a href="http://en.wikipedia.org/wiki/ISO_8601"
        /// target="_blank">ISO 8601</a> standard. This encodes the time as follows:
        /// <br><br><ul><li>Combined date and time in UTC: 2013-06-10T10:00Z</li><li>Combined date
        /// and time in localtime with the timezone offset: 2013-06-10T12:00+02:00</li><li>Combined
        /// date and time in localtime with the timezone offset: 2013-06-10T07:00-03:00</li></ul> The
        /// examples refer all to the same time.
        /// </summary>
        [JsonProperty("end")]
        public string End { get; set; }

        /// <summary>
        /// The name of the radio show.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specify the start time by using the <a href="http://en.wikipedia.org/wiki/ISO_8601"
        /// target="_blank">ISO 8601</a> standard. This encodes the time as follows:
        /// <br><br><ul><li>Combined date and time in UTC: 2013-06-10T10:00Z</li><li>Combined date
        /// and time in localtime with the timezone offset: 2013-06-10T12:00+02:00</li><li>Combined
        /// date and time in localtime with the timezone offset: 2013-06-10T07:00-03:00</li></ul> The
        /// examples refer all to the same time.
        /// </summary>
        [JsonProperty("start")]
        public string Start { get; set; }

        /// <summary>
        /// The stream encoder.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The stream URL which must end in a filename or a semicolon such as
        /// <br><ul><li>http://signal.hackerspaces.org:8090/signal.mp3</li><li>http://85.214.64.213:8060/;</ul>
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Data of various sensors in your space (e.g. temperature, humidity, amount of Club-Mate
    /// left, …). The only canonical property is the <em>temp</em> property, additional sensor
    /// types may be defined by you. In this case, you are requested to share your definition for
    /// inclusion in this specification.
    /// </summary>
    public partial class Sensors
    {
        /// <summary>
        /// How rich is your hackerspace?
        /// </summary>
        [JsonProperty("account_balance", NullValueHandling = NullValueHandling.Ignore)]
        public AccountBalance[] AccountBalance { get; set; }

        /// <summary>
        /// Barometer sensor
        /// </summary>
        [JsonProperty("barometer", NullValueHandling = NullValueHandling.Ignore)]
        public Barometer[] Barometer { get; set; }

        /// <summary>
        /// How much Mate and beer is in your fridge?
        /// </summary>
        [JsonProperty("beverage_supply", NullValueHandling = NullValueHandling.Ignore)]
        public BeverageSupply[] BeverageSupply { get; set; }

        /// <summary>
        /// Sensor type to indicate if a certain door is locked.
        /// </summary>
        [JsonProperty("door_locked", NullValueHandling = NullValueHandling.Ignore)]
        public DoorLocked[] DoorLocked { get; set; }

        /// <summary>
        /// Humidity sensor
        /// </summary>
        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        public Humidity[] Humidity { get; set; }

        /// <summary>
        /// This sensor type is to specify the currently active  ethernet or wireless network
        /// devices. You can create different instances for each network type.
        /// </summary>
        [JsonProperty("network_connections", NullValueHandling = NullValueHandling.Ignore)]
        public NetworkConnection[] NetworkConnections { get; set; }

        /// <summary>
        /// Specify the number of people that are currently in your space. Optionally you can define
        /// a list of names.
        /// </summary>
        [JsonProperty("people_now_present", NullValueHandling = NullValueHandling.Ignore)]
        public PeopleNowPresent[] PeopleNowPresent { get; set; }

        /// <summary>
        /// The power consumption of a specific device or of your whole space.
        /// </summary>
        [JsonProperty("power_consumption", NullValueHandling = NullValueHandling.Ignore)]
        public PowerConsumption[] PowerConsumption { get; set; }

        /// <summary>
        /// Compound radiation sensor. Check this <a rel="nofollow"
        /// href="https://sites.google.com/site/diygeigercounter/gm-tubes-supported"
        /// target="_blank">resource</a>.
        /// </summary>
        [JsonProperty("radiation", NullValueHandling = NullValueHandling.Ignore)]
        public Radiation Radiation { get; set; }

        /// <summary>
        /// Temperature sensor. To convert from one unit of temperature to another consider <a
        /// href="http://en.wikipedia.org/wiki/Temperature_conversion_formulas"
        /// target="_blank">Wikipedia</a>.
        /// </summary>
        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public Temperature[] Temperature { get; set; }

        /// <summary>
        /// Specify the number of space members.
        /// </summary>
        [JsonProperty("total_member_count", NullValueHandling = NullValueHandling.Ignore)]
        public TotalMemberCount[] TotalMemberCount { get; set; }

        /// <summary>
        /// Your wind sensor.
        /// </summary>
        [JsonProperty("wind", NullValueHandling = NullValueHandling.Ignore)]
        public Wind[] Wind { get; set; }
    }

    public partial class AccountBalance
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// If you have more than one account you can use this field to specify where it is.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// Give your sensor instance a name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// What's the currency? Please use the ones provided, in the next version you can use
        /// currency definitions according to <a href="https://en.wikipedia.org/wiki/ISO_4217"
        /// target="_blank">ISO 4217</a>
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// How much?
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Barometer
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class BeverageSupply
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Room 1</samp> or <samp>Room 2</samp> or
        /// <samp>Room 3</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The unit, either <samp>btl</samp> for bottles or <samp>crt</samp> for crates.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class DoorLocked
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>front door</samp>, <samp>chill room</samp> or
        /// <samp>lab</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public bool Value { get; set; }
    }

    public partial class Humidity
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class NetworkConnection
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// The machines that are currently connected with the network.
        /// </summary>
        [JsonProperty("machines", NullValueHandling = NullValueHandling.Ignore)]
        public Machine[] Machines { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// This field is optional but you can use it to the network type such as <samp>wifi</samp>
        /// or <samp>cable</samp>. You can even expose the number of <a
        /// href="https://spacefed.net/wiki/index.php/Spacenet"
        /// target="_blank">spacenet</a>-authenticated connections.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// The amount of network connections.
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Machine
    {
        /// <summary>
        /// The machine's MAC address of the format <samp>D3:3A:DB:EE:FF:00</samp>.
        /// </summary>
        [JsonProperty("mac")]
        public string Mac { get; set; }

        /// <summary>
        /// The machine name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class PeopleNowPresent
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// If you use multiple sensor instances for different rooms, use this field to indicate the
        /// location.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// Give this sensor a name if necessary at all. Use the location field for the rooms. This
        /// field is not intended to be used for names of hackerspace members. Use the field 'names'
        /// instead.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// List of hackerspace members that are currently occupying the space.
        /// </summary>
        [JsonProperty("names", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Names { get; set; }

        /// <summary>
        /// The amount of present people.
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class PowerConsumption
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    /// <summary>
    /// Compound radiation sensor. Check this <a rel="nofollow"
    /// href="https://sites.google.com/site/diygeigercounter/gm-tubes-supported"
    /// target="_blank">resource</a>.
    /// </summary>
    public partial class Radiation
    {
        /// <summary>
        /// An alpha sensor
        /// </summary>
        [JsonProperty("alpha", NullValueHandling = NullValueHandling.Ignore)]
        public Alpha[] Alpha { get; set; }

        /// <summary>
        /// A beta sensor
        /// </summary>
        [JsonProperty("beta", NullValueHandling = NullValueHandling.Ignore)]
        public Beta[] Beta { get; set; }

        /// <summary>
        /// A sensor which cannot filter beta and gamma radiation separately.
        /// </summary>
        [JsonProperty("beta_gamma", NullValueHandling = NullValueHandling.Ignore)]
        public BetaGamma[] BetaGamma { get; set; }

        /// <summary>
        /// A gamma sensor
        /// </summary>
        [JsonProperty("gamma", NullValueHandling = NullValueHandling.Ignore)]
        public Gamma[] Gamma { get; set; }
    }

    public partial class Alpha
    {
        /// <summary>
        /// The conversion from the <em>cpm</em> unit to another unit hardly depends on your tube
        /// type. See the description of the value field to see how to use the conversion factor.
        /// <strong>Note:</strong> only trust your manufacturer if it comes to the actual factor
        /// value. The internet seems <a rel="nofollow"
        /// href="http://sapporohibaku.wordpress.com/2011/10/15/conversion-factor/"
        /// target="_blank">full of wrong copy & pastes</a>, don't even trust your neighbour
        /// hackerspace. If in doubt ask the tube manufacturer.
        /// </summary>
        [JsonProperty("conversion_factor", NullValueHandling = NullValueHandling.Ignore)]
        public double? ConversionFactor { get; set; }

        /// <summary>
        /// The dead time in µs. See the description of the value field to see how to use the dead
        /// time.
        /// </summary>
        [JsonProperty("dead_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? DeadTime { get; set; }

        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Choose the appropriate unit for your radiation sensor instance.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Observed counts per minute (ocpm) or actual radiation value. If the value are the
        /// observed counts then the dead_time and conversion_factor fields must be defined as well.
        /// CPM formula: <div>cpm = ocpm ( 1 + 1 / (1 - ocpm x dead_time) )</div> Conversion formula:
        /// <div>µSv/h = cpm x conversion_factor</div>
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Beta
    {
        /// <summary>
        /// The conversion from the <em>cpm</em> unit to another unit hardly depends on your tube
        /// type. See the description of the value field to see how to use the conversion factor.
        /// <strong>Note:</strong> only trust your manufacturer if it comes to the actual factor
        /// value. The internet seems <a rel="nofollow"
        /// href="http://sapporohibaku.wordpress.com/2011/10/15/conversion-factor/"
        /// target="_blank">full of wrong copy & pastes</a>, don't even trust your neighbour
        /// hackerspace. If in doubt ask the tube manufacturer.
        /// </summary>
        [JsonProperty("conversion_factor", NullValueHandling = NullValueHandling.Ignore)]
        public double? ConversionFactor { get; set; }

        /// <summary>
        /// The dead time in µs. See the description of the value field to see how to use the dead
        /// time.
        /// </summary>
        [JsonProperty("dead_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? DeadTime { get; set; }

        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Choose the appropriate unit for your radiation sensor instance.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Observed counts per minute (ocpm) or actual radiation value. If the value are the
        /// observed counts then the dead_time and conversion_factor fields must be defined as well.
        /// CPM formula: <div>cpm = ocpm ( 1 + 1 / (1 - ocpm x dead_time) )</div> Conversion formula:
        /// <div>µSv/h = cpm x conversion_factor</div>
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class BetaGamma
    {
        /// <summary>
        /// The conversion from the <em>cpm</em> unit to another unit hardly depends on your tube
        /// type. See the description of the value field to see how to use the conversion factor.
        /// <strong>Note:</strong> only trust your manufacturer if it comes to the actual factor
        /// value. The internet seems <a rel="nofollow"
        /// href="http://sapporohibaku.wordpress.com/2011/10/15/conversion-factor/"
        /// target="_blank">full of wrong copy & pastes</a>, don't even trust your neighbour
        /// hackerspace. If in doubt ask the tube manufacturer.
        /// </summary>
        [JsonProperty("conversion_factor", NullValueHandling = NullValueHandling.Ignore)]
        public double? ConversionFactor { get; set; }

        /// <summary>
        /// The dead time in µs. See the description of the value field to see how to use the dead
        /// time.
        /// </summary>
        [JsonProperty("dead_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? DeadTime { get; set; }

        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Choose the appropriate unit for your radiation sensor instance.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Observed counts per minute (ocpm) or actual radiation value. If the value are the
        /// observed counts then the dead_time and conversion_factor fields must be defined as well.
        /// CPM formula: <div>cpm = ocpm ( 1 + 1 / (1 - ocpm x dead_time) )</div> Conversion formula:
        /// <div>µSv/h = cpm x conversion_factor</div>
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Gamma
    {
        /// <summary>
        /// The conversion from the <em>cpm</em> unit to another unit hardly depends on your tube
        /// type. See the description of the value field to see how to use the conversion factor.
        /// <strong>Note:</strong> only trust your manufacturer if it comes to the actual factor
        /// value. The internet seems <a rel="nofollow"
        /// href="http://sapporohibaku.wordpress.com/2011/10/15/conversion-factor/"
        /// target="_blank">full of wrong copy & pastes</a>, don't even trust your neighbour
        /// hackerspace. If in doubt ask the tube manufacturer.
        /// </summary>
        [JsonProperty("conversion_factor", NullValueHandling = NullValueHandling.Ignore)]
        public double? ConversionFactor { get; set; }

        /// <summary>
        /// The dead time in µs. See the description of the value field to see how to use the dead
        /// time.
        /// </summary>
        [JsonProperty("dead_time", NullValueHandling = NullValueHandling.Ignore)]
        public double? DeadTime { get; set; }

        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Choose the appropriate unit for your radiation sensor instance.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// Observed counts per minute (ocpm) or actual radiation value. If the value are the
        /// observed counts then the dead_time and conversion_factor fields must be defined as well.
        /// CPM formula: <div>cpm = ocpm ( 1 + 1 / (1 - ocpm x dead_time) )</div> Conversion formula:
        /// <div>µSv/h = cpm x conversion_factor</div>
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Temperature
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The unit of the sensor value.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class TotalMemberCount
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Specify the location if your hackerspace has different departments (for whatever reason).
        /// This field is for one department. Every department should have its own sensor instance.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// You can use this field to specify if this sensor instance counts active or inactive
        /// members.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The amount of your space members.
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Wind
    {
        /// <summary>
        /// An extra field that you can use to attach some additional information to this sensor
        /// instance.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// The location of your sensor such as <samp>Outside</samp>, <samp>Inside</samp>,
        /// <samp>Ceiling</samp>, <samp>Roof</samp> or <samp>Room 1</samp>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// This field is an additional field to give your sensor a name. This can be useful if you
        /// have multiple sensors in the same location.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public partial class Properties
    {
        /// <summary>
        /// The wind direction in degrees.
        /// </summary>
        [JsonProperty("direction")]
        public Direction Direction { get; set; }

        /// <summary>
        /// Height above mean sea level.
        /// </summary>
        [JsonProperty("elevation")]
        public Elevation Elevation { get; set; }

        [JsonProperty("gust")]
        public Gust Gust { get; set; }

        [JsonProperty("speed")]
        public Speed Speed { get; set; }
    }

    /// <summary>
    /// The wind direction in degrees.
    /// </summary>
    public partial class Direction
    {
        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    /// <summary>
    /// Height above mean sea level.
    /// </summary>
    public partial class Elevation
    {
        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Gust
    {
        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    public partial class Speed
    {
        /// <summary>
        /// The unit of the sensor value. You should always define the unit though if the sensor is a
        /// flag of a boolean type then you can of course omit it.
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The sensor value
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }
    }

    /// <summary>
    /// A flag indicating if the hackerspace uses SpaceFED, a federated login scheme so that
    /// visiting hackers can use the space WiFi with their home space credentials.
    /// </summary>
    public partial class Spacefed
    {
        /// <summary>
        /// See the <a target="_blank"
        /// href="https://spacefed.net/wiki/index.php/Category:Howto/Spacenet">wiki</a>.
        /// </summary>
        [JsonProperty("spacenet")]
        public bool Spacenet { get; set; }

        /// <summary>
        /// See the <a target="_blank"
        /// href="https://spacefed.net/wiki/index.php/Category:Howto/Spacephone">wiki</a>.
        /// </summary>
        [JsonProperty("spacephone")]
        public bool Spacephone { get; set; }

        /// <summary>
        /// See the <a target="_blank"
        /// href="https://spacefed.net/wiki/index.php/Category:Howto/Spacesaml">wiki</a>.
        /// </summary>
        [JsonProperty("spacesaml")]
        public bool Spacesaml { get; set; }
    }

    /// <summary>
    /// A collection of status-related data: actual open/closed status, icons, last change
    /// timestamp etc.
    /// </summary>
    public partial class State
    {
        /// <summary>
        /// Icons that show the status graphically
        /// </summary>
        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public Icon Icon { get; set; }

        /// <summary>
        /// The Unix timestamp when the space status changed most recently
        /// </summary>
        [JsonProperty("lastchange", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lastchange { get; set; }

        /// <summary>
        /// An additional free-form string, could be something like <samp>'open for public'</samp>,
        /// <samp>'members only'</samp> or whatever you want it to be
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// A flag which indicates if the space is currently open or closed. The state 'undefined'
        /// can be achieved by assigning this field the value 'null' (without the quotes). In most
        /// (all?) programming languages this is evaluated to false so that no app should break
        /// </summary>
        [JsonProperty("open")]
        public bool? Open { get; set; }

        /// <summary>
        /// The person who lastly changed the state e.g. opened or closed the space.
        /// </summary>
        [JsonProperty("trigger_person", NullValueHandling = NullValueHandling.Ignore)]
        public string TriggerPerson { get; set; }
    }

    /// <summary>
    /// Icons that show the status graphically
    /// </summary>
    public partial class Icon
    {
        /// <summary>
        /// The URL to your customized space logo showing a closed space
        /// </summary>
        [JsonProperty("closed")]
        public string Closed { get; set; }

        /// <summary>
        /// The URL to your customized space logo showing an open space
        /// </summary>
        [JsonProperty("open")]
        public string Open { get; set; }
    }

    /// <summary>
    /// A mapping of stream types to stream URLs. If you use other stream types make a <a
    /// href="https://github.com/spaceapi/schema/pulls" target="_blank">pull request</a> or
    /// prefix yours with <samp>ext_</samp>.
    /// </summary>
    public partial class Stream
    {
        /// <summary>
        /// Your mpg stream URL. Example: <samp>{"mp4": "http://example.org/stream.mpg"}</samp>
        /// </summary>
        [JsonProperty("m4", NullValueHandling = NullValueHandling.Ignore)]
        public string M4 { get; set; }

        /// <summary>
        /// Your mjpeg stream URL. Example: <samp>{"mjpeg": "http://example.org/stream.mjpeg"}</samp>
        /// </summary>
        [JsonProperty("mjpeg", NullValueHandling = NullValueHandling.Ignore)]
        public string Mjpeg { get; set; }

        /// <summary>
        /// Your ustream stream URL. Example: <samp>{"ustream":
        /// "http://www.ustream.tv/channel/hackspsps"}</samp>
        /// </summary>
        [JsonProperty("ustream", NullValueHandling = NullValueHandling.Ignore)]
        public string Ustream { get; set; }
    }

    /// <summary>
    /// The version of SpaceAPI your endpoint uses
    /// </summary>
    public enum Api { The013 };

    /// <summary>
    /// Cache update cycle. This field must match the basic regular expression
    /// <code>^[mhd]\.[0-9]{2}$</code>, where the first field specifies a unit of time
    /// (<code>m</code> for 1 minute, <code>h</code> for 1 hour, <code>d</code> for 1 day), and
    /// the second field specifies how many of this unit should be skipped between updates. For
    /// example, <samp>m.10</samp> means one updates every 10 minutes, <samp>h.03</samp> means
    /// one update every 3 hours, and <samp>d.01</samp> means one update every day.
    /// </summary>
    public enum Schedule { D01, H01, H02, H04, H08, H12, M02, M05, M10, M15, M30 };

    public enum IssueReportChannel { Email, IssueMail, Ml, Twitter };

    /// <summary>
    /// The stream encoder.
    /// </summary>
    public enum RadioShowType { Mp3, Ogg };

    /// <summary>
    /// What's the currency? Please use the ones provided, in the next version you can use
    /// currency definitions according to <a href="https://en.wikipedia.org/wiki/ISO_4217"
    /// target="_blank">ISO 4217</a>
    /// </summary>
    public enum AccountBalanceUnit { Btc, Eur, Gbp, Usd };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum BarometerUnit { HPa };

    /// <summary>
    /// The unit, either <samp>btl</samp> for bottles or <samp>crt</samp> for crates.
    /// </summary>
    public enum BeverageSupplyUnit { Btl, Crt };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum HumidityUnit { Empty };

    /// <summary>
    /// This field is optional but you can use it to the network type such as <samp>wifi</samp>
    /// or <samp>cable</samp>. You can even expose the number of <a
    /// href="https://spacefed.net/wiki/index.php/Spacenet"
    /// target="_blank">spacenet</a>-authenticated connections.
    /// </summary>
    public enum NetworkConnectionType { Cable, Spacenet, Wifi };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum PowerConsumptionUnit { MW, Va, W };

    /// <summary>
    /// Choose the appropriate unit for your radiation sensor instance.
    /// </summary>
    public enum AlphaUnit { Cpm, MSvA, RH, ΜSvA, ΜSvH };

    /// <summary>
    /// The unit of the sensor value.
    /// </summary>
    public enum TemperatureUnit { C, De, F, K, N, R, Ré, Rø };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum DirectionUnit { Empty };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum ElevationUnit { M };

    /// <summary>
    /// The unit of the sensor value. You should always define the unit though if the sensor is a
    /// flag of a boolean type then you can of course omit it.
    /// </summary>
    public enum GustUnit { KmH, Kn, MS };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ApiConverter.Singleton,
                ScheduleConverter.Singleton,
                IssueReportChannelConverter.Singleton,
                RadioShowTypeConverter.Singleton,
                AccountBalanceUnitConverter.Singleton,
                BarometerUnitConverter.Singleton,
                BeverageSupplyUnitConverter.Singleton,
                HumidityUnitConverter.Singleton,
                NetworkConnectionTypeConverter.Singleton,
                PowerConsumptionUnitConverter.Singleton,
                AlphaUnitConverter.Singleton,
                TemperatureUnitConverter.Singleton,
                DirectionUnitConverter.Singleton,
                ElevationUnitConverter.Singleton,
                GustUnitConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ApiConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Api) || t == typeof(Api?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "0.13")
            {
                return Api.The013;
            }
            throw new Exception("Cannot unmarshal type Api");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Api)untypedValue;
            if (value == Api.The013)
            {
                serializer.Serialize(writer, "0.13");
                return;
            }
            throw new Exception("Cannot marshal type Api");
        }

        public static readonly ApiConverter Singleton = new ApiConverter();
    }

    internal class ScheduleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Schedule) || t == typeof(Schedule?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "d.01":
                    return Schedule.D01;
                case "h.01":
                    return Schedule.H01;
                case "h.02":
                    return Schedule.H02;
                case "h.04":
                    return Schedule.H04;
                case "h.08":
                    return Schedule.H08;
                case "h.12":
                    return Schedule.H12;
                case "m.02":
                    return Schedule.M02;
                case "m.05":
                    return Schedule.M05;
                case "m.10":
                    return Schedule.M10;
                case "m.15":
                    return Schedule.M15;
                case "m.30":
                    return Schedule.M30;
            }
            throw new Exception("Cannot unmarshal type Schedule");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Schedule)untypedValue;
            switch (value)
            {
                case Schedule.D01:
                    serializer.Serialize(writer, "d.01");
                    return;
                case Schedule.H01:
                    serializer.Serialize(writer, "h.01");
                    return;
                case Schedule.H02:
                    serializer.Serialize(writer, "h.02");
                    return;
                case Schedule.H04:
                    serializer.Serialize(writer, "h.04");
                    return;
                case Schedule.H08:
                    serializer.Serialize(writer, "h.08");
                    return;
                case Schedule.H12:
                    serializer.Serialize(writer, "h.12");
                    return;
                case Schedule.M02:
                    serializer.Serialize(writer, "m.02");
                    return;
                case Schedule.M05:
                    serializer.Serialize(writer, "m.05");
                    return;
                case Schedule.M10:
                    serializer.Serialize(writer, "m.10");
                    return;
                case Schedule.M15:
                    serializer.Serialize(writer, "m.15");
                    return;
                case Schedule.M30:
                    serializer.Serialize(writer, "m.30");
                    return;
            }
            throw new Exception("Cannot marshal type Schedule");
        }

        public static readonly ScheduleConverter Singleton = new ScheduleConverter();
    }

    internal class IssueReportChannelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(IssueReportChannel) || t == typeof(IssueReportChannel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "email":
                    return IssueReportChannel.Email;
                case "issue_mail":
                    return IssueReportChannel.IssueMail;
                case "ml":
                    return IssueReportChannel.Ml;
                case "twitter":
                    return IssueReportChannel.Twitter;
            }
            throw new Exception("Cannot unmarshal type IssueReportChannel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (IssueReportChannel)untypedValue;
            switch (value)
            {
                case IssueReportChannel.Email:
                    serializer.Serialize(writer, "email");
                    return;
                case IssueReportChannel.IssueMail:
                    serializer.Serialize(writer, "issue_mail");
                    return;
                case IssueReportChannel.Ml:
                    serializer.Serialize(writer, "ml");
                    return;
                case IssueReportChannel.Twitter:
                    serializer.Serialize(writer, "twitter");
                    return;
            }
            throw new Exception("Cannot marshal type IssueReportChannel");
        }

        public static readonly IssueReportChannelConverter Singleton = new IssueReportChannelConverter();
    }

    internal class RadioShowTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RadioShowType) || t == typeof(RadioShowType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "mp3":
                    return RadioShowType.Mp3;
                case "ogg":
                    return RadioShowType.Ogg;
            }
            throw new Exception("Cannot unmarshal type RadioShowType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RadioShowType)untypedValue;
            switch (value)
            {
                case RadioShowType.Mp3:
                    serializer.Serialize(writer, "mp3");
                    return;
                case RadioShowType.Ogg:
                    serializer.Serialize(writer, "ogg");
                    return;
            }
            throw new Exception("Cannot marshal type RadioShowType");
        }

        public static readonly RadioShowTypeConverter Singleton = new RadioShowTypeConverter();
    }

    internal class AccountBalanceUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AccountBalanceUnit) || t == typeof(AccountBalanceUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BTC":
                    return AccountBalanceUnit.Btc;
                case "EUR":
                    return AccountBalanceUnit.Eur;
                case "GBP":
                    return AccountBalanceUnit.Gbp;
                case "USD":
                    return AccountBalanceUnit.Usd;
            }
            throw new Exception("Cannot unmarshal type AccountBalanceUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AccountBalanceUnit)untypedValue;
            switch (value)
            {
                case AccountBalanceUnit.Btc:
                    serializer.Serialize(writer, "BTC");
                    return;
                case AccountBalanceUnit.Eur:
                    serializer.Serialize(writer, "EUR");
                    return;
                case AccountBalanceUnit.Gbp:
                    serializer.Serialize(writer, "GBP");
                    return;
                case AccountBalanceUnit.Usd:
                    serializer.Serialize(writer, "USD");
                    return;
            }
            throw new Exception("Cannot marshal type AccountBalanceUnit");
        }

        public static readonly AccountBalanceUnitConverter Singleton = new AccountBalanceUnitConverter();
    }

    internal class BarometerUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BarometerUnit) || t == typeof(BarometerUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "hPA")
            {
                return BarometerUnit.HPa;
            }
            throw new Exception("Cannot unmarshal type BarometerUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BarometerUnit)untypedValue;
            if (value == BarometerUnit.HPa)
            {
                serializer.Serialize(writer, "hPA");
                return;
            }
            throw new Exception("Cannot marshal type BarometerUnit");
        }

        public static readonly BarometerUnitConverter Singleton = new BarometerUnitConverter();
    }

    internal class BeverageSupplyUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BeverageSupplyUnit) || t == typeof(BeverageSupplyUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "btl":
                    return BeverageSupplyUnit.Btl;
                case "crt":
                    return BeverageSupplyUnit.Crt;
            }
            throw new Exception("Cannot unmarshal type BeverageSupplyUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BeverageSupplyUnit)untypedValue;
            switch (value)
            {
                case BeverageSupplyUnit.Btl:
                    serializer.Serialize(writer, "btl");
                    return;
                case BeverageSupplyUnit.Crt:
                    serializer.Serialize(writer, "crt");
                    return;
            }
            throw new Exception("Cannot marshal type BeverageSupplyUnit");
        }

        public static readonly BeverageSupplyUnitConverter Singleton = new BeverageSupplyUnitConverter();
    }

    internal class HumidityUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HumidityUnit) || t == typeof(HumidityUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "%")
            {
                return HumidityUnit.Empty;
            }
            throw new Exception("Cannot unmarshal type HumidityUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (HumidityUnit)untypedValue;
            if (value == HumidityUnit.Empty)
            {
                serializer.Serialize(writer, "%");
                return;
            }
            throw new Exception("Cannot marshal type HumidityUnit");
        }

        public static readonly HumidityUnitConverter Singleton = new HumidityUnitConverter();
    }

    internal class NetworkConnectionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(NetworkConnectionType) || t == typeof(NetworkConnectionType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cable":
                    return NetworkConnectionType.Cable;
                case "spacenet":
                    return NetworkConnectionType.Spacenet;
                case "wifi":
                    return NetworkConnectionType.Wifi;
            }
            throw new Exception("Cannot unmarshal type NetworkConnectionType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (NetworkConnectionType)untypedValue;
            switch (value)
            {
                case NetworkConnectionType.Cable:
                    serializer.Serialize(writer, "cable");
                    return;
                case NetworkConnectionType.Spacenet:
                    serializer.Serialize(writer, "spacenet");
                    return;
                case NetworkConnectionType.Wifi:
                    serializer.Serialize(writer, "wifi");
                    return;
            }
            throw new Exception("Cannot marshal type NetworkConnectionType");
        }

        public static readonly NetworkConnectionTypeConverter Singleton = new NetworkConnectionTypeConverter();
    }

    internal class PowerConsumptionUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PowerConsumptionUnit) || t == typeof(PowerConsumptionUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "VA":
                    return PowerConsumptionUnit.Va;
                case "W":
                    return PowerConsumptionUnit.W;
                case "mW":
                    return PowerConsumptionUnit.MW;
            }
            throw new Exception("Cannot unmarshal type PowerConsumptionUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PowerConsumptionUnit)untypedValue;
            switch (value)
            {
                case PowerConsumptionUnit.Va:
                    serializer.Serialize(writer, "VA");
                    return;
                case PowerConsumptionUnit.W:
                    serializer.Serialize(writer, "W");
                    return;
                case PowerConsumptionUnit.MW:
                    serializer.Serialize(writer, "mW");
                    return;
            }
            throw new Exception("Cannot marshal type PowerConsumptionUnit");
        }

        public static readonly PowerConsumptionUnitConverter Singleton = new PowerConsumptionUnitConverter();
    }

    internal class AlphaUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlphaUnit) || t == typeof(AlphaUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "cpm":
                    return AlphaUnit.Cpm;
                case "mSv/a":
                    return AlphaUnit.MSvA;
                case "r/h":
                    return AlphaUnit.RH;
                case "µSv/a":
                    return AlphaUnit.ΜSvA;
                case "µSv/h":
                    return AlphaUnit.ΜSvH;
            }
            throw new Exception("Cannot unmarshal type AlphaUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlphaUnit)untypedValue;
            switch (value)
            {
                case AlphaUnit.Cpm:
                    serializer.Serialize(writer, "cpm");
                    return;
                case AlphaUnit.MSvA:
                    serializer.Serialize(writer, "mSv/a");
                    return;
                case AlphaUnit.RH:
                    serializer.Serialize(writer, "r/h");
                    return;
                case AlphaUnit.ΜSvA:
                    serializer.Serialize(writer, "µSv/a");
                    return;
                case AlphaUnit.ΜSvH:
                    serializer.Serialize(writer, "µSv/h");
                    return;
            }
            throw new Exception("Cannot marshal type AlphaUnit");
        }

        public static readonly AlphaUnitConverter Singleton = new AlphaUnitConverter();
    }

    internal class TemperatureUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TemperatureUnit) || t == typeof(TemperatureUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "K":
                    return TemperatureUnit.K;
                case "°C":
                    return TemperatureUnit.C;
                case "°De":
                    return TemperatureUnit.De;
                case "°F":
                    return TemperatureUnit.F;
                case "°N":
                    return TemperatureUnit.N;
                case "°R":
                    return TemperatureUnit.R;
                case "°Ré":
                    return TemperatureUnit.Ré;
                case "°Rø":
                    return TemperatureUnit.Rø;
            }
            throw new Exception("Cannot unmarshal type TemperatureUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TemperatureUnit)untypedValue;
            switch (value)
            {
                case TemperatureUnit.K:
                    serializer.Serialize(writer, "K");
                    return;
                case TemperatureUnit.C:
                    serializer.Serialize(writer, "°C");
                    return;
                case TemperatureUnit.De:
                    serializer.Serialize(writer, "°De");
                    return;
                case TemperatureUnit.F:
                    serializer.Serialize(writer, "°F");
                    return;
                case TemperatureUnit.N:
                    serializer.Serialize(writer, "°N");
                    return;
                case TemperatureUnit.R:
                    serializer.Serialize(writer, "°R");
                    return;
                case TemperatureUnit.Ré:
                    serializer.Serialize(writer, "°Ré");
                    return;
                case TemperatureUnit.Rø:
                    serializer.Serialize(writer, "°Rø");
                    return;
            }
            throw new Exception("Cannot marshal type TemperatureUnit");
        }

        public static readonly TemperatureUnitConverter Singleton = new TemperatureUnitConverter();
    }

    internal class DirectionUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DirectionUnit) || t == typeof(DirectionUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "°")
            {
                return DirectionUnit.Empty;
            }
            throw new Exception("Cannot unmarshal type DirectionUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DirectionUnit)untypedValue;
            if (value == DirectionUnit.Empty)
            {
                serializer.Serialize(writer, "°");
                return;
            }
            throw new Exception("Cannot marshal type DirectionUnit");
        }

        public static readonly DirectionUnitConverter Singleton = new DirectionUnitConverter();
    }

    internal class ElevationUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ElevationUnit) || t == typeof(ElevationUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "m")
            {
                return ElevationUnit.M;
            }
            throw new Exception("Cannot unmarshal type ElevationUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ElevationUnit)untypedValue;
            if (value == ElevationUnit.M)
            {
                serializer.Serialize(writer, "m");
                return;
            }
            throw new Exception("Cannot marshal type ElevationUnit");
        }

        public static readonly ElevationUnitConverter Singleton = new ElevationUnitConverter();
    }

    internal class GustUnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GustUnit) || t == typeof(GustUnit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "km/h":
                    return GustUnit.KmH;
                case "kn":
                    return GustUnit.Kn;
                case "m/s":
                    return GustUnit.MS;
            }
            throw new Exception("Cannot unmarshal type GustUnit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GustUnit)untypedValue;
            switch (value)
            {
                case GustUnit.KmH:
                    serializer.Serialize(writer, "km/h");
                    return;
                case GustUnit.Kn:
                    serializer.Serialize(writer, "kn");
                    return;
                case GustUnit.MS:
                    serializer.Serialize(writer, "m/s");
                    return;
            }
            throw new Exception("Cannot marshal type GustUnit");
        }

        public static readonly GustUnitConverter Singleton = new GustUnitConverter();
    }
}
