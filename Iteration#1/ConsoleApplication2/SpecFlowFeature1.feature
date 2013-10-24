Feature:  health check

    as a system administrator

    I want a version health check

    In order to know the Alteryx service is working


   Scenario:  Active Districts

   Given the alteryx service is running at "http://gallery.alteryx.com"

   When I invoke the GET at "api/districts"

   Then I see at least 6 active districts