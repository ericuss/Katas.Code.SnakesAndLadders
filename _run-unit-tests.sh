
echo Executing: "$0"

docker-compose -f docker-compose-unit-tests.yml build unit-tests && docker-compose -f docker-compose-unit-tests.yml run unit-tests