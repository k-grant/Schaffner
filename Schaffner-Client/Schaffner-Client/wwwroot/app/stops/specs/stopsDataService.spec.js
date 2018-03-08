'use strict';

describe('stopsDataService', function () {

    beforeEach(module('schaffner'));

    it('should issue a GET request to /api/stops/ when getAllStopPredictions is invoked',
        inject(function (stopsDataService, $httpBackend) {
            $httpBackend = $injector.get('$httpBackend');
            $httpBackend.expectGET('SchaffnerRestAPIBaseURL+ /stops/');
            $httpBackend.when('GET', SchaffnerRestAPIBaseURL+'/stops/').respond({});

            stopsDataService.getAllStopPredictions();

            $httpBackend.flush();
            $httpBackend.verifyNoOutstandingExpectation();
            $httpBackend.verifyNoOutstandingRequest();
        })
    )

    it('should issue a GET request to /api/stops/1 when getStopPredictions is invoked with 1',
        inject(function (stopsDataService, $httpBackend, SchaffnerRestAPIBaseURL) {
            $httpBackend = $injector.get('$httpBackend');
            $httpBackend.expectGET(SchaffnerRestAPIBaseURL+ '/stops/1');
            $httpBackend.when('GET', SchaffnerRestAPIBaseURL+ '/stops/1').respond({});

            stopsDataService.getStopPredictions(1);

            $httpBackend.flush();
            $httpBackend.verifyNoOutstandingExpectation();
            $httpBackend.verifyNoOutstandingRequest();
        })
    )
});