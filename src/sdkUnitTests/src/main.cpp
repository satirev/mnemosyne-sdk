// Copyright (c) 2020 Mnemosyne

#include "function.h"

#include "gtest/gtest.h"
#include "src/gtest-all.cc"

TEST(UnitTestTests, ExpectEqual)
{
    EXPECT_EQ(Foo(), 5);
}

TEST(UnitTestTests, ExpectNotEqual)
{
    EXPECT_NE(Foo(), 0);
    EXPECT_NE(Foo(), 1);
    EXPECT_NE(Foo(), 6);
}

int main(int argc, char** argv)
{
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}