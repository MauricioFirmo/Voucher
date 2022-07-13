export class FlightDetailSabreDTO {
    acS_FlightDetailRSACS: {
        itineraryResponseList: [
            {
                airline: string;
                flight: string;
                origin: string;
                departureDate: string;
                departureTime: string;
                scheduledDepartureDate: string;
                scheduledDepartureTime: string;
                estimatedDepartureDate: string;
                estimatedDepartureTime: string;
                departureGate: string;
                boardingTime: {
                    boardingIndicator: string;
                    value: string
                };
                destination: string;
                finalDestination: string;
                arrivalDate: string;
                arrivalTime: string;
                scheduledArrivalDate: string;
                scheduledArrivalTime: string;
                estimatedArrivalDate: string;
                estimatedArrivalTime: string;
                baggageClaim: string;
                aircraftType: {
                    change: string;
                    value: string
                };
                flightStatus: string;
                aircraftConfigNumber: string;
                aircraftRegistration: string;
                checkinRuleNumber: string;
                seatConfig: string;
                bagCheckInOption: string;
                autoOn: string;
                heldSeat: string;
                freeTextInfoList: [
                    {
                        lineID: string;
                        editCode: string;
                        textLine: [
                            string
                        ]
                    }
                ];
                apisInfoList: [
                    {
                        city: string;
                        country: string;
                        aqq: string;
                        esta: string;
                        sf: string;
                        dcar: string;
                        dcad: string;
                        doco: string;
                        docv: string;
                        pctc: string;
                        docs: string;
                        docType: string;
                        api: string;
                        iapp: string;
                        tim: string;
                        twapp: string
                    }
                ]
            }
        ];
        legInfoList: LegInfo[];
        passengerCounts: [
            {
                authorized: number;
                authorizedSpecified: boolean;
                booked: number;
                bookedSpecified: boolean;
                available: number;
                availableSpecified: boolean;
                thru: number;
                thruSpecified: boolean;
                local: number;
                localSpecified: boolean;
                nonRevenueLocal: number;
                nonRevenueLocalSpecified: boolean;
                nonRevenueThru: number;
                nonRevenueThruSpecified: boolean;
                paperTicket: number;
                paperTicketSpecified: boolean;
                electronicTicket: number;
                electronicTicketSpecified: boolean;
                kiosk: number;
                kioskSpecified: boolean;
                standbyRestriction: string;
                meals: number;
                mealsSpecified: boolean;
                specialMeals: number;
                specialMealsSpecified: boolean;
                setups: number;
                setupsSpecified: boolean;
                localOnBoard: number;
                localOnBoardSpecified: boolean;
                totalOnBoard: number;
                totalOnBoardSpecified: boolean;
                totalBoardingPassIssued: number;
                totalBoardingPassIssuedSpecified: boolean;
                classOfService: string
            }
        ];
        jumpSeat: {
            cockpit: [
                {
                    inUse: boolean;
                    inUseSpecified: boolean;
                    value: number
                }
            ];
            cabin: [
                {
                    inUse: boolean;
                    inUseSpecified: boolean;
                    value: number
                }
            ]
        };
        totalPlan: number;
        totalPlanSpecified: boolean;
        apisInfoList: [
            {
                city: string;
                country: string;
                aqq: string;
                esta: string;
                sf: string;
                dcar: string;
                dcad: string;
                doco: string;
                docv: string;
                pctc: string;
                docs: string;
                docType: string;
                api: string;
                iapp: string;
                tim: string;
                twapp: string
            }
        ];
        freeTextInfoList: [
            {
                lineID: string;
                editCode: string;
                textLine: [
                    string
                ]
            }
        ];
        result: {
            errorSource: {
                id: string;
                value: string
            };
            status: number;
            completionStatus: number;
            completionStatusSpecified: boolean;
            system: {
                id: string;
                value: string
            };
            systemSpecificResults: [
                {
                    errorMessage: {
                        code: string;
                        value: string
                    };
                    shortText: string;
                    element: string;
                    recordID: string;
                    docURL: string;
                    diagnosticResults: [
                        null
                    ];
                    serviceName: string
                }
            ];
            conversationID: string;
            messageId: string;
            version: string;
            timeStamp: Date;
            timeStampSpecified: boolean
        }
    }
    shareCode: string;
}
export class LegInfo {
    legNoOperationInd: string;
    legCity: string;
    controllingCityInd: string;
    legStatus: string;
    legDate: string;
    legArrivalTime: string;
    legDepartureTime: string;
    legApp: string;
    changeOfGauge: string
}