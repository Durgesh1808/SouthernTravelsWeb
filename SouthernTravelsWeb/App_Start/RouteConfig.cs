using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace SouthernTravelsWeb
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Enable Friendly URLs
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            // InternationalTours with CountryId and ZoneId
            routes.MapPageRoute(
                "IntlToursCountryZone",
                "InternationalTours-{name}-{slug}_{countryId}_{zoneId}",
                "~/IntItenaryDetails.aspx"
            );

            // InternationalTours with TourId only
            routes.MapPageRoute(
                "IntlToursTourId",
                "InternationalTours-{name}-{slug}_{tourId}",
                "~/IntItenaryDetails.aspx"
            );

            // InternationalTours Offer
            routes.MapPageRoute(
                "IntlToursOffer",
                "InternationalTours_Offer{offerCode}-{name}-{slug}_{tourId}",
                "~/IntItenaryDetails.aspx"
            );

            // Thank You page (fix handler from .ascx to .aspx, also fix param count)
            routes.MapPageRoute(
                "IntlToursThankYou",
                "InternationalTours-ThankYou_{tourId}",
                "~/IntEnquiryThankYou.aspx"
            );

            // Enquiry for Classic Europe Tour
            routes.MapPageRoute(
                "EnquiryClassicEurope",
                "EnquiryofClassicEuropeTour_{id}",
                "~/Intenquiryform.aspx"
            );

            // Enquiry for Enchanting Europe Tour
            routes.MapPageRoute(
                "EnquiryEnchantingEurope",
                "EnquiryofEnchantingEuropeTour_{id}",
                "~/Intenquiryform.aspx"
            );

            // Fixed Departure Itinerary
            routes.MapPageRoute(
                "FixedDeparture",
                "Fixed-Departure-Itinerary-{title}_{tourId}",
                "~/FixedTouritinerary.aspx"
            );

            // FSB Fixed Departure with UTM parameters
            routes.MapPageRoute(
                "FSBFixedDepartureUTM",
                "FSB-Fixed-Departure-Itinerary-{title}_{tourId}_{utm_source}_{utm_medium}_{utm_term}_{utm_content}_{utm_campaign}",
                "~/FixedTouritinerary.aspx"
            );

            // Fixed Departure with JDate
            routes.MapPageRoute(
                "FixedDepartureWithDate",
                "Fixed-Departure-Itinerary_JDate-{title}_{tourId}_{jdate}",
                "~/FixedTouritinerary.aspx"
            );

            // Fixed Departure LTC
            routes.MapPageRoute(
                "FixedDepartureLTC",
                "Fixed-Departure-LTC-Itinerary-{title}_{tourId}",
                "~/FixedTouritinerary.aspx"
            );

            // Fixed Departure Booking
            routes.MapPageRoute(
                "FixedDepartureBooking",
                "Fixed-Departure-Booking-{title}_{tourId}",
                "~/TourBooking.aspx"
            );

            // Fixed Departure Booking with JDate (from rewrite config, add missing route)
            routes.MapPageRoute(
                "FixedDepartureBookingJDate",
                "Fixed-Departure-Booking_JDate-{title}_{tourId}_{jdate}",
                "~/TourBooking.aspx"
            );

            // Tour Booking (generic)
            routes.MapPageRoute(
                "TourBooking",
                "Tour-Booking-{tourName}_{tourId}",
                "~/TourBooking.aspx"
            );

            // Seat Availability (from rewrite config)
            routes.MapPageRoute(
                "SeatAvailability",
                "Seat_Availability_{tourName}_{jdate}_{tourId}_{combination}_{A}_{C}_{orderid}_{ltc}_{sid}",
                "~/TourBooking.aspx"
            );

            // Booking (two patterns from rewrite config)
            routes.MapPageRoute(
                "BookingWithDate",
                "Booking-{tourName}_{orderid}_{tourId}_{jdate}",
                "~/TourBooking.aspx"
            );

            routes.MapPageRoute(
                "BookingBookMore",
                "Booking-{something}_{orderid}_{bookMore}",
                "~/TourBooking.aspx"
            );

            // Special Tour Itinerary
            routes.MapPageRoute(
                "SpecialTourItinerary",
                "Holiday-Packages-Itinerary-{tourId}",
                "~/SpecialTouritinerary.aspx"
            );

            // Special Tour Itinerary with UTM params
            routes.MapPageRoute(
                "FSBHolidayPackagesUTM",
                "FSB-Holiday-Packages-Itinerary-{tourId}_{utm_source}_{utm_medium}_{utm_term}_{utm_content}_{utm_campaign}",
                "~/SpecialTouritinerary.aspx"
            );

            // Special Tour Itinerary with JDate
            routes.MapPageRoute(
                "HolidayPackagesWithDate",
                "Holiday-Packages-Itinerary_JDate-{something}_{jdate}",
                "~/SpecialTouritinerary.aspx"
            );

            // Application Rejection
            routes.MapPageRoute(
                "AppRejection",
                "AppRej_{app}_{req}",
                "~/AppRej.aspx"
            );

        }
    }
}
